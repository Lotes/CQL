using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MainCore.CQL.WPF.Composer
{ 
    public class FilterBoxViewModel: ViewModelBase
    {
        public static FilterBoxViewModel NewEditor(IContext context, QueryPartSuggestion suggestion)
        {
            var result = new FilterBoxViewModel(context, false, suggestion.Part);
            result.FilterState = result.QueryPart.Validate(context);
            if (result.FilterState == FilterBoxState.HasErrors)
                result.FilterState = FilterBoxState.Editing;
            return result;
        }
        public static FilterBoxViewModel NewBooleanLiteral(IContext context, bool negate, bool value)
        {
            return new FilterBoxViewModel(context, negate, new BooleanLiteralViewModel(value)) { state = FilterBoxState.ReadyToUse };
        }
        public static FilterBoxViewModel NewComparsion(IContext context, bool negate, Field field, BinaryOperator op, ComparsionValueViewModel value)
        {
            return new FilterBoxViewModel(context, negate, new FieldComparsionViewModel(context, field, op, value)) { state = FilterBoxState.ReadyToUse };
        }
        public static FilterBoxViewModel NewBooleanConstant(IContext context, bool negate, Constant constant)
        {
            return new FilterBoxViewModel(context, negate, new BooleanConstantViewModel(context, constant)) { state = FilterBoxState.ReadyToUse };
        }

        private bool negate;
        private bool last;
        private FilterBoxState state;
        private QueryPartViewModel queryPart;

        private FilterBoxViewModel(IContext context, bool negate, QueryPartViewModel queryPart)
        {
            this.Context = context;
            this.queryPart = queryPart;
            queryPart.PropertyChanged += (sender, args) => RaiseChanged();
            queryPart.ReadyModeRequested += (sender, args) => Validate();
            state = FilterBoxState.Editing;
            this.negate = negate;
            this.last = false;
            AddCommand = new RelayCommand<QueryPartSuggestion>(suggestion => Added?.Invoke(this, suggestion));
            DeleteCommand = new RelayCommand(() => Deleted?.Invoke(this, new EventArgs()));
            DoneCommand = new RelayCommand(() => Validate());
        }

        public QueryPartViewModel QueryPart { get { return queryPart; } }

        public IContext Context { get; private set; }
        public bool Negate { get { return negate; } set { negate = value; RaiseChanged(); } }
        public bool IsLast { get { return last; } set { last = value; RaisePropertyChanged(() => IsLast); } }
        public event EventHandler<QueryPartSuggestion> Added;
        public event EventHandler Deleted;
        public event EventHandler Changed;
        public RelayCommand<QueryPartSuggestion> AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand DoneCommand { get; private set; }

        public FilterBoxState FilterState
        {
            get
            {
                return state;
            }

            private set
            {
                state = value;
                RaisePropertyChanged(() => FilterState);
                RaiseChanged();
            }
        }
        private void Validate()
        {
            FilterState = QueryPart.Validate(Context);
        }

        protected void RaiseChanged()
        {
            Changed?.Invoke(this, new EventArgs());
        }
        protected IExpression MayNegate(IExpression expression)
        {
            if (negate)
            {
                if (expression is BinaryOperationExpression)
                    expression = new ParenthesisExpression(null, expression);
                expression = new UnaryOperationExpression(null, UnaryOperator.Not, expression);
            }
            return expression;
        }

        public IExpression ToExpression()
        {
            if(FilterState == FilterBoxState.ReadyToUse)
                return MayNegate(QueryPart.ToExpression());
            return new BooleanLiteralExpression(null, true);
        }      
    }
}
