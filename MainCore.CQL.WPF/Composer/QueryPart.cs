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

namespace MainCore.CQL.WPF.Composer
{ 
    public class QueryPart: ViewModelBase
    {
        public static QueryPart NewEditor(IContext context)
        {
            return new QueryPart(context, false, QueryPartType.FieldComparsion, null, null, null, null);
        }
        public static QueryPart NewBooleanLiteral(IContext context, bool negate, bool value)
        {
            return new QueryPart(context, negate, QueryPartType.BooleanLiteral, null, null, QueryValueType.BooleanLiteral, value) { state = QueryPartState.ReadyToUse };
        }
        public static QueryPart NewComparsion(IContext context, bool negate, string name, BinaryOperator op, QueryValueType valueType, object value)
        {
            return new QueryPart(context, negate, QueryPartType.FieldComparsion, name, op, valueType, value) { state = QueryPartState.ReadyToUse };
        }
        public static QueryPart NewBooleanConstant(IContext context, bool negate, string name)
        {
            return new QueryPart(context, negate, QueryPartType.BooleanConstant, name, null, null, null) { state = QueryPartState.ReadyToUse };
        }

        private bool negate;
        private bool last;
        private QueryPartState state;
        private QueryPartType type;

        private QueryPart(IContext context, bool negate, QueryPartType type, string name, BinaryOperator? op, QueryValueType? valueType, object value)
        {
            this.Context = context;
            this.type = type;
            state = QueryPartState.Editing;
            this.negate = negate;
            this.last = false;
            AddCommand = new RelayCommand<Suggestion>(suggestion => Added?.Invoke(this, suggestion));
            DeleteCommand = new RelayCommand(() => Deleted?.Invoke(this, new EventArgs()));
            DoneCommand = new RelayCommand(() => State = Validate());
        }

        private QueryPartState Validate()
        {
            return QueryPartState.HasErrors;
        }

        public IContext Context { get; private set; }

        public bool Negate { get { return negate; } set { negate = value; RaiseChanged(); } }
        public bool IsLast { get { return last; } set { last = value; RaisePropertyChanged(() => IsLast); } }

        public event EventHandler<Suggestion> Added;
        public event EventHandler Deleted;
        public event EventHandler Changed;
        public RelayCommand<Suggestion> AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand DoneCommand { get; private set; }

        public QueryPartState State
        {
            get
            {
                return state;
            }

            private set
            {
                state = value;
                RaisePropertyChanged(() => State);
            }
        }

        public QueryPartType Type
        {
            get
            {
                return type;
            }

            private set
            {
                type = value;
                RaisePropertyChanged(() => Type);
            }
        }

        protected void RaiseChanged()
        {
            Changed?.Invoke(this, new EventArgs());
        }
        protected IExpression MayNegate(IExpression expression)
        {
            if (negate)
                expression = new UnaryOperationExpression(null, UnaryOperator.Not, expression);
            return expression;
        }

        public IExpression ToExpression()
        {
            //if(state == QueryPartState.Editing)
                return new BooleanLiteralExpression(null, true);
            /*switch (type)
            {
                case QueryPartType.BooleanLiteral: return MayNegate(new BooleanLiteralExpression(null, (bool)Value));
                case QueryPartType.BooleanConstant: return MayNegate(new MultiIdExpression(null, Name));
                case QueryPartType.FieldComparsion: return MayNegate(new BinaryOperationExpression(null, Operator, new MultiIdExpression(null, Name), ValueToExpression()));
            }
            return new BooleanLiteralExpression(null, false);*/
        }

        public IExpression ValueToExpression()
        {
            return new BooleanLiteralExpression(null, true);
            /*switch (ValueType)
            {
                case QueryValueType.BooleanLiteral: return new BooleanLiteralExpression(null, (bool)Value);
                case QueryValueType.DecimalLiteral: return new DecimalLiteralExpression(null, (double)Value);
                case QueryValueType.StringLiteral: return new StringLiteralExpression(null, (string)Value);
                case QueryValueType.Variable: return new MultiIdExpression(null, (string)Value);
            }
            throw new InvalidOperationException("Unknown type!");*/
        }
    }
}
