using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.WPF.Composer
{
    public abstract class QueryPart
    {
        private bool negate;
        public QueryPart(bool negate)
        {
            this.negate = negate;
            DeleteCommand = new RelayCommand(() => Deleted?.Invoke(this, new EventArgs()));
        }

        public bool Negate
        {
            get { return negate; }
            set { negate = value; RaiseChanged(); }
        }

        public event EventHandler Deleted;
        public event EventHandler Changed;

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

        public abstract IExpression ToExpression();
        public RelayCommand DeleteCommand { get; private set; }
    }

    public class FieldQueryPart : QueryPart
    {
        public FieldQueryPart(bool negate, Field field, BinaryOperator booleanOperator, QueryValue value)
            : base(negate)
        {
            Field = field;
            BooleanOperator = booleanOperator;
            Value = value;
        }

        public Field Field { get; private set; }
        public BinaryOperator BooleanOperator { get; private set; }
        public QueryValue Value { get; private set; }

        public override IExpression ToExpression()
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanConstantPart : QueryPart
    {
        public BooleanConstantPart(bool negate, Constant constant)
            : base(negate)
        {
            Constant = constant;
        }

        public Constant Constant { get; private set; }

        public override IExpression ToExpression()
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanFunctionInvocationPart : QueryPart
    {
        public BooleanFunctionInvocationPart(bool negate, AbstractFunction function, ObservableCollection<QueryValue> parameters)
            : base(negate)
        {
            Function = function;
            Parameters = parameters;
        }

        public AbstractFunction Function { get; private set; }
        public ObservableCollection<QueryValue> Parameters { get; private set; }

        public override IExpression ToExpression()
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanLiteralPart : QueryPart
    {
        private bool value;
        //Yeah... pretty lame... i know
        public BooleanLiteralPart(bool negate, bool value)
            : base(negate)
        {
            this.value = value;
        }

        public bool Value
        {
            get { return this.value; }
            set { this.value = value; RaiseChanged(); }
        }

        public override IExpression ToExpression()
        {
            return MayNegate(new BooleanLiteralExpression(null, value));
        }
    }

    public class QueryValue
    {
    }
}
