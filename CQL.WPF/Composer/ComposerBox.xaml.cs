using CQL.Contexts;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CQL.WPF.Composer
{
    public partial class ComposerBox : UserControl
    {
        private bool isUpdating = false;

        public ComposerBox()
        {
            InitializeComponent();
        }

        public IContext Context
        {
            get { return (IContext)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public Query Query
        {
            get { return (Query)GetValue(QueryProperty); }
            set { SetValue(QueryProperty, value); }
        }
        public ComposerStatus Status
        {
            get { return (ComposerStatus)GetValue(StatusProperty.DependencyProperty); }
            private set { SetValue(StatusProperty, value); }
        }
        public ObservableCollection<FilterBoxViewModel> Filters
        {
            get { return (ObservableCollection<FilterBoxViewModel>)GetValue(FiltersProperty.DependencyProperty); }
            private set { SetValue(FiltersProperty, value); }
        }

        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(IContext), typeof(ComposerBox), new PropertyMetadata(null, changedStatic));
        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(Query), typeof(ComposerBox), new PropertyMetadata(null, changedStatic));
        public static readonly DependencyPropertyKey StatusProperty =
            DependencyProperty.RegisterReadOnly("Status", typeof(ComposerStatus), typeof(ComposerBox), new PropertyMetadata(ComposerStatus.Uninitialized));
        public static readonly DependencyPropertyKey FiltersProperty =
            DependencyProperty.RegisterReadOnly("Filters", typeof(ObservableCollection<FilterBoxViewModel>), typeof(ComposerBox), new PropertyMetadata(new ObservableCollection<FilterBoxViewModel>()));

        private static void changedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (ComposerBox)d;
            if (control.isUpdating)
                return;
            if (control.Context == null || control.Query == null)
            {
                control.Status = ComposerStatus.Uninitialized;
            }
            else
                control.TrySplitQuery();
        }

        private void TrySplitQuery()
        {
            var parts = new List<FilterBoxViewModel>();
            var stack = new Stack<IExpression>();
            stack.Push(Query.Expression);
            while (stack.Any())
            {
                var top = stack.Pop();
                var and = top as BinaryOperationExpression;
                FilterBoxViewModel part;
                if (and != null && and.Operator == BinaryOperator.And)
                {
                    stack.Push(and.RightExpression);
                    stack.Push(and.LeftExpression);
                }
                else if (TryMakePart(top, out part))
                {
                    parts.Add(part);
                    BindPartToEvents(part);
                }
                else
                {
                    Status = ComposerStatus.CanNotDisplay;
                    return;
                }
            }
            Status = ComposerStatus.Ok;

            Filters.Clear();
            foreach(var prt in parts)
                Filters.Add(prt);
            if(Filters.Any())
                Filters.Last().IsLast = true;
        }

        private void BindPartToEvents(FilterBoxViewModel part)
        {
            part.Changed += OnChange;
            part.Deleted += OnDelete;
            part.Added += OnAdd;
        }

        private static readonly IEnumerable<BinaryOperator> ComparsionOperators = new[] 
        {
            BinaryOperator.Contains,
            BinaryOperator.DoesNotContain,
            BinaryOperator.Equals,
            BinaryOperator.GreaterThan,
            BinaryOperator.GreaterThanEquals,
            BinaryOperator.In,
            BinaryOperator.Is,
            BinaryOperator.LessThan,
            BinaryOperator.LessThanEquals,
            BinaryOperator.NotEquals,
            BinaryOperator.NotIn
        };

        private IExpression Uncast(IExpression expression)
        {
            while (expression is CastExpression && ((CastExpression)expression).Kind == TypeSystem.CoercionKind.Implicit)
                expression = ((CastExpression)expression).Expression;
            return expression;
        }

        private bool TryMakePart(IExpression expression, out FilterBoxViewModel part)
        {
            //ATTENTION! Theses lines ignore the type system and assume a "normal" usage of boolean operations.
            part = null;

            //uncast first
            expression = Uncast(expression);

            //maybe get negation
            var not = expression as UnaryOperationExpression;
            var negate = false;
            if (not != null && not.Operator == UnaryOperator.Not)
            {
                negate = true;
                expression = not.Expression;
            }

            //maybe still casting? So uncast
            expression = Uncast(expression);

            //field comparsion?
            var comparsion = expression as BinaryOperationExpression;
            if(comparsion != null && ComparsionOperators.Contains(comparsion.Operator))
            {
                var multiId = Uncast(comparsion.LeftExpression) as VariableExpression;
                ComparsionValueViewModel comValue = null;
                if (multiId == null || !(Context.Get(multiId.Name) is Field) || !TryMakeValue(Uncast(comparsion.RightExpression), out comValue))
                    return false;
                var field = Context.Get(multiId.Name) as Field;
                part = FilterBoxViewModel.NewComparsion(Context, negate, field, comparsion.Operator, comValue);
                return true;
            }

            //constant query?
            var constantQuery = expression as VariableExpression;
            if (constantQuery != null && Context.Get(constantQuery.Name) is Constant)
            {
                var constant = (Constant)Context.Get(constantQuery.Name);
                if (constant.FieldType != typeof(bool))
                    return false;
                part = FilterBoxViewModel.NewBooleanConstant(Context, negate, constant);
                return true;
            }

            //boolean literal
            var booleanLiteral = expression as BooleanLiteralExpression;
            if (booleanLiteral != null)
            {
                part = FilterBoxViewModel.NewBooleanLiteral(Context, negate, booleanLiteral.Value);
                return true;
            }

            return false;
        }

        private bool TryMakeValue(IExpression expression, out ComparsionValueViewModel value)
        {
            value = null;

            var booleanLiteralExpression = expression as BooleanLiteralExpression;
            if(booleanLiteralExpression != null)
            {
                value = new BooleanLiteralValueViewModel(booleanLiteralExpression.Value);
                return true;
            }

            var stringLiteralExpression = expression as StringLiteralExpression;
            if (stringLiteralExpression != null)
            {
                value = new StringLiteralValueViewModel(stringLiteralExpression.Value);
                return true;
            }

            var decimalLiteralExpression = expression as DecimalLiteralExpression;
            if (decimalLiteralExpression != null)
            {
                value = new DecimalLiteralValueViewModel(decimalLiteralExpression.Value);
                return true;
            }

            var signedExpression = expression as UnaryOperationExpression;
            if (signedExpression != null)
            {
                var innerLiteralExpression = signedExpression.Expression as DecimalLiteralExpression;
                if (innerLiteralExpression != null)
                {
                    var sign = signedExpression.Operator == UnaryOperator.Plus ? 1 : signedExpression.Operator == UnaryOperator.Minus ? -1 : 0;
                    value = new DecimalLiteralValueViewModel(sign * innerLiteralExpression.Value);
                    return true;
                }
            }

            return false;
        }

        private void OnChange(object sender, EventArgs args)
        {
            UpdateQuery();
        }

        private void OnAdd(object sender, QueryPartSuggestion suggestion)
        {
            Filters.Last().IsLast = false;
            var last = FilterBoxViewModel.NewEditor(Context, suggestion);
            BindPartToEvents(last);
            last.IsLast = true;
            Filters.Add(last);
            UpdateQuery();
        }

        private void OnDelete(object sender, EventArgs args)
        {
            var part = (FilterBoxViewModel)sender;
            if (Filters.Count > 1)
                Filters.Remove(part);
            Filters.Last().IsLast = true;
            UpdateQuery();
        }

        private void UpdateQuery()
        {
            isUpdating = true;
            try
            {
                var expression = Filters.Where(p => p.FilterState == FilterBoxState.ReadyToUse).Select(p => p.ToExpression()).Aggregate((lhs, rhs) => new BinaryOperationExpression(null, BinaryOperator.And, lhs, rhs));
                var query = new Query(null, expression);
                query.Validate(Context);
                Query = query;
            }
            catch { }
            finally { isUpdating = false; }
        }
    }
}
