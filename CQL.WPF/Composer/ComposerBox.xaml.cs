﻿using CQL.Contexts;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CQL.WPF.Composer
{
    public partial class ComposerBox : UserControl
    {
        private bool isUpdating = false;

        public ComposerBox()
        {
            InitializeComponent();
        }

        public IEvaluationScope Context
        {
            get { return (IEvaluationScope)GetValue(ContextProperty); }
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
            DependencyProperty.Register("Context", typeof(IEvaluationScope), typeof(ComposerBox), new PropertyMetadata(null, ChangedStatic));
        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(Query), typeof(ComposerBox), new PropertyMetadata(null, ChangedStatic));
        public static readonly DependencyPropertyKey StatusProperty =
            DependencyProperty.RegisterReadOnly("Status", typeof(ComposerStatus), typeof(ComposerBox), new PropertyMetadata(ComposerStatus.Uninitialized));
        public static readonly DependencyPropertyKey FiltersProperty =
            DependencyProperty.RegisterReadOnly("Filters", typeof(ObservableCollection<FilterBoxViewModel>), typeof(ComposerBox), new PropertyMetadata(new ObservableCollection<FilterBoxViewModel>()));

        private static void ChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
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
                if (top is BinaryOperationExpression and && and.Operator == BinaryOperator.And)
                {
                    stack.Push(and.RightExpression);
                    stack.Push(and.LeftExpression);
                }
                else if (TryMakePart(top, out FilterBoxViewModel part))
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
            var negate = false;
            if (expression is UnaryOperationExpression not && not.Operator == UnaryOperator.Not)
            {
                negate = true;
                expression = not.Expression;
            }

            //maybe still casting? So uncast
            expression = Uncast(expression);

            //field comparsion?
            if (expression is BinaryOperationExpression comparsion && ComparsionOperators.Contains(comparsion.Operator))
            {
                var multiId = Uncast(comparsion.LeftExpression) as VariableExpression;
                if (multiId == null || !(Context.TryGetVariable(multiId.Identifier, out IVariableDefinition variable)) || !TryMakeValue(Uncast(comparsion.RightExpression), out ComparsionValueViewModel comValue))
                    return false;
                var field = variable;
                part = FilterBoxViewModel.NewComparsion(Context.ToValidationScope(), negate, field.ToValidationVariable(), comparsion.Operator, comValue);
                return true;
            }

            //boolean literal
            if (expression is BooleanLiteralExpression booleanLiteral)
            {
                part = FilterBoxViewModel.NewBooleanLiteral(Context.ToValidationScope(), negate, booleanLiteral.Value);
                return true;
            }

            return false;
        }

        private bool TryMakeValue(IExpression expression, out ComparsionValueViewModel value)
        {
            value = null;

            if (expression is BooleanLiteralExpression booleanLiteralExpression)
            {
                value = new BooleanLiteralValueViewModel(booleanLiteralExpression.Value);
                return true;
            }

            if (expression is StringLiteralExpression stringLiteralExpression)
            {
                value = new StringLiteralValueViewModel(stringLiteralExpression.Value);
                return true;
            }

            if (expression is FloatingPointLiteralExpression decimalLiteralExpression)
            {
                value = new DecimalLiteralValueViewModel(decimalLiteralExpression.Value);
                return true;
            }

            if (expression is UnaryOperationExpression signedExpression)
            {
                if (signedExpression.Expression is FloatingPointLiteralExpression innerLiteralExpression)
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
            var last = FilterBoxViewModel.NewEditor(Context.ToValidationScope(), suggestion);
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
                query.Validate(Context.ToValidationScope());
                Query = query;
            }
            catch { }
            finally { isUpdating = false; }
        }
    }
}
