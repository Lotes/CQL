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
    public enum QueryPartType
    {
        BooleanLiteral,
        BooleanConstant,
        FieldComparsion
    }

    public enum QueryValueType
    {
        BooleanLiteral,
        DecimalLiteral,
        StringLiteral,
        Variable
    }

    public enum QueryPartState
    {
        Editing,
        HasErrors,
        ReadyToUse
    }

    public class QueryPart: ViewModelBase
    {
        public static QueryPart NewEditor()
        {
            return new QueryPart(false, QueryPartType.FieldComparsion, null, null, null, null);
        }
        public static QueryPart NewBooleanLiteral(bool negate, bool value)
        {
            return new QueryPart(negate, QueryPartType.BooleanLiteral, null, null, QueryValueType.BooleanLiteral, value) { state = QueryPartState.ReadyToUse };
        }
        public static QueryPart NewComparsion(bool negate, string name, BinaryOperator op, QueryValueType valueType, object value)
        {
            return new QueryPart(negate, QueryPartType.FieldComparsion, name, op, valueType, value) { state = QueryPartState.ReadyToUse };
        }
        public static QueryPart NewConstant(bool negate, string name)
        {
            return new QueryPart(negate, QueryPartType.BooleanConstant, name, null, null, null) { state = QueryPartState.ReadyToUse };
        }

        private bool negate;
        private bool last;
        private QueryPartState state;
        private QueryPartType type;
        private object value;

        private QueryPart(bool negate, QueryPartType type, string name, BinaryOperator? op, QueryValueType? valueType, object value)
        {
            this.type = type;
            this.Operator = op ?? BinaryOperator.Add; //egal für type != QueryType.FieldComparsion
            this.value = value;
            this.ValueType = valueType ?? QueryValueType.Variable; //egal
            state = QueryPartState.Editing;
            this.negate = negate;
            this.last = false;
            AddCommand = new RelayCommand(() => Added?.Invoke(this, new EventArgs()));
            DeleteCommand = new RelayCommand(() => Deleted?.Invoke(this, new EventArgs()));
        }

        public string Name { get; private set; }
        public BinaryOperator Operator { get; private set; }
        public QueryValueType ValueType { get; private set; }
        public object Value { get { return value; } set { this.value = value; RaiseChanged(); } }

        public bool Negate { get { return negate; } set { negate = value; RaiseChanged(); } }
        public bool IsLast { get { return last; } set { last = value; RaisePropertyChanged(() => IsLast); } }

        public event EventHandler Added;
        public event EventHandler Deleted;
        public event EventHandler Changed;
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

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
            if(state == QueryPartState.Editing)
                return new BooleanLiteralExpression(null, true);
            switch (type)
            {
                case QueryPartType.BooleanLiteral: return MayNegate(new BooleanLiteralExpression(null, (bool)Value));
                case QueryPartType.BooleanConstant: return MayNegate(new MultiIdExpression(null, Name));
                case QueryPartType.FieldComparsion: return MayNegate(new BinaryOperationExpression(null, Operator, new MultiIdExpression(null, Name), ValueToExpression()));
            }
            return new BooleanLiteralExpression(null, false);
        }

        public IExpression ValueToExpression()
        {
            switch (ValueType)
            {
                case QueryValueType.BooleanLiteral: return new BooleanLiteralExpression(null, (bool)Value);
                case QueryValueType.DecimalLiteral: return new DecimalLiteralExpression(null, (double)Value);
                case QueryValueType.StringLiteral: return new StringLiteralExpression(null, (string)Value);
                case QueryValueType.Variable: return new MultiIdExpression(null, (string)Value);
            }
            throw new InvalidOperationException("Unknown type!");
        }
    }
}
