using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
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

namespace MainCore.CQL.WPF.Composer
{
    public partial class ComposerBox : UserControl
    {
        public enum ComposerStatus
        {
            Uninitialized,
            CanNotDisplay,
            Ok
        }

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
        public ObservableCollection<QueryPart> QueryParts
        {
            get { return (ObservableCollection<QueryPart>)GetValue(QueryPartsProperty); }
            set { SetValue(QueryPartsProperty, value); }
        }

        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(IContext), typeof(ComposerBox), new PropertyMetadata(null, changedStatic));
        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(Query), typeof(ComposerBox), new PropertyMetadata(null, changedStatic));
        public static readonly DependencyPropertyKey StatusProperty =
            DependencyProperty.RegisterReadOnly("Status", typeof(ComposerStatus), typeof(ComposerBox), new PropertyMetadata(ComposerStatus.Uninitialized));
        public static readonly DependencyProperty QueryPartsProperty =
            DependencyProperty.Register("QueryParts", typeof(ObservableCollection<QueryPart>), typeof(ComposerBox), new PropertyMetadata(new ObservableCollection<QueryPart>()));

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
            var parts = new List<QueryPart>();
            var stack = new Stack<IExpression>();
            stack.Push(Query.Expression);
            while (stack.Any())
            {
                var top = stack.Pop();
                var and = top as BinaryOperationExpression;
                QueryPart part;
                if (and != null && and.Operator == BinaryOperator.And)
                {
                    stack.Push(and.RightExpression);
                    stack.Push(and.LeftExpression);
                }
                else if (TryMakePart(top, out part))
                {
                    parts.Add(part);
                    part.Changed += OnChange;
                    part.Deleted += OnDelete;
                }
                else
                {
                    Status = ComposerStatus.CanNotDisplay;
                    return;
                }
            }
            Status = ComposerStatus.Ok;

            QueryParts.Clear();
            foreach(var prt in parts)
                QueryParts.Add(prt);
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

        private bool TryMakePart(IExpression expression, out QueryPart part)
        {
            //ATTENTION! Theses lines ignore the type system and assume a "normal" usage of boolean operations.
            part = null;

            //maybe get negation
            var not = expression as UnaryOperationExpression;
            var negate = false;
            if (not != null && not.Operator == UnaryOperator.Not)
            {
                negate = true;
                expression = not.Expression;
            }

            //field comparsion?
            var comparsion = expression as BinaryOperationExpression;
            if(comparsion != null && ComparsionOperators.Contains(comparsion.Operator))
            {
                var multiId = comparsion.LeftExpression as MultiIdExpression;
                QueryValue value;
                if (multiId == null || !(Context.Get(multiId.Name) is Field) || !TryMakeValue(comparsion.RightExpression, out value))
                    return false;
                part = new FieldQueryPart(negate, (Field)Context.Get(multiId.Name), comparsion.Operator, value);
                return true;
            }

            //constant query?
            var constantQuery = expression as MultiIdExpression;
            if (constantQuery != null && Context.Get(constantQuery.Name) is Constant)
            {
                var constant = (Constant)Context.Get(constantQuery.Name);
                if (constant.FieldType != typeof(bool))
                    return false;
                part = new BooleanConstantPart(negate, constant);
                return true;
            }

            //function invokation?
            var functionCall = expression as FunctionCallExpression;
            if (functionCall != null && Context.Get(functionCall.Name) is AbstractFunction)
            {
                var function = (AbstractFunction)Context.Get(functionCall.Name);
                var values = new ObservableCollection<QueryValue>();
                if (function.Arity != functionCall.Parameters.Count() || function.ResultType != typeof(bool) || functionCall.Parameters.Any(ex =>
                    {
                        QueryValue value;
                        var result = !TryMakeValue(ex, out value);
                        values.Add(value);
                        return result;
                    }))
                    return false;
                part = new BooleanFunctionInvocationPart(negate, function, values);
                return true;
            }

            //boolean literal
            var booleanLiteral = expression as BooleanLiteralExpression;
            if (booleanLiteral != null)
            {
                part = new BooleanLiteralPart(negate, booleanLiteral.Value);
                return true;
            }

            return false;
        }

        private bool TryMakeValue(IExpression rightExpression, out QueryValue value)
        {
            value = null;
            return true;
        }

        private void OnChange(object sender, EventArgs args)
        {
            UpdateQuery();
        }

        private void OnDelete(object sender, EventArgs args)
        {
            var part = (QueryPart)sender;
            if (QueryParts.Count > 1)
                QueryParts.Remove(part);
            UpdateQuery();
        }

        private void UpdateQuery()
        {
            var expression = QueryParts.Select(p => p.ToExpression()).Aggregate((lhs, rhs) => new BinaryOperationExpression(null, BinaryOperator.And, lhs, rhs));
            isUpdating = true;
            try
            {
                var query = new Query(null, expression);
                query.Validate(Context);
                Query = query;
            }
            finally { isUpdating = false; }
        }
    }
}
