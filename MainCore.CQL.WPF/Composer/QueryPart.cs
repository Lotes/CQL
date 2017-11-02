using GalaSoft.MvvmLight;
using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.WPF.Composer
{
    public abstract class QueryPartViewModel: ViewModelBase
    {
        public abstract IExpression ToExpression();
        public abstract FilterBoxState Validate(IContext context);
    }

    public class FieldComparsionViewModel : QueryPartViewModel
    {
        private Field field;
        private IContext context;
        private BinaryOperator op;
        private ComparsionValueViewModel value;
        public FieldComparsionViewModel(IContext context, Field field, BinaryOperator? op = null, ComparsionValueViewModel value = null)
        {
            this.context = context;
            this.field = field;
        }

        public Field Field { get { return field; } }
        public BinaryOperator Operator { get { return op; } set { op = value; RaisePropertyChanged(() => Operator); } }
        public ComparsionValueViewModel Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }

        public override IExpression ToExpression()
        {
            return new BinaryOperationExpression(null, op,
                new MultiIdExpression(null, field.Name),
                value.ToExpression());
        }

        public override FilterBoxState Validate(IContext context)
        {
            return FilterBoxState.ReadyToUse; //TODO
        }
    }
    public class BooleanConstantViewModel : QueryPartViewModel
    {
        private Constant constant;
        private IContext context;

        public BooleanConstantViewModel(IContext context, Constant constant)
        {
            if (constant.FieldType != typeof(bool))
                throw new ArgumentException("Constant must be a bool type!");
            this.constant = constant;
            this.context = context;
        }

        public Constant Constant
        {
            get { return constant; }
            set { constant = value; RaisePropertyChanged(() => Constant); }
        }

        public IEnumerable<Constant> Constants
        {
            get
            {
                return context.Constants
                    .Where(c => c.FieldType == typeof(bool))
                    .OrderBy(c => c.Name, Comparer<string>.Create((lhs, rhs) => string.Compare(lhs, rhs, StringComparison.CurrentCultureIgnoreCase))).ToArray();
            }
        }

        public override IExpression ToExpression()
        {
            return new MultiIdExpression(null, constant.Name);
        }

        public override FilterBoxState Validate(IContext context)
        {
            return context.Get(constant.Name) == constant && constant.FieldType == typeof(bool)
                ? FilterBoxState.ReadyToUse
                : FilterBoxState.HasErrors;
        }
    }
    public class BooleanLiteralViewModel : QueryPartViewModel
    {
        private bool value;

        public BooleanLiteralViewModel(bool value)
        {
            this.value = value;
        }

        public bool Value
        {
            get { return value; }
            set
            {
                this.value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public override IExpression ToExpression()
        {
            return new BooleanLiteralExpression(null, value);
        }

        public override FilterBoxState Validate(IContext context)
        {
            return FilterBoxState.ReadyToUse;
        }
    }

    public abstract class ComparsionValueViewModel: ViewModelBase
    {
        public abstract IExpression ToExpression();
    }

    public class BooleanLiteralValueViewModel : ComparsionValueViewModel
    {
        private bool value;
        public BooleanLiteralValueViewModel(bool value)
        {
            this.value = value;
        }
        public bool Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }
        public override IExpression ToExpression()
        {
            return new BooleanLiteralExpression(null, value);
        }
    }

    public class DecimalLiteralValueViewModel : ComparsionValueViewModel
    {
        private double value;
        public DecimalLiteralValueViewModel(double value) { this.value = value; }
        public double Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }
        public override IExpression ToExpression()
        {
            return new DecimalLiteralExpression(null, value);
        }
    }
    public class StringLiteralValueViewModel : ComparsionValueViewModel
    {
        private string value;
        public StringLiteralValueViewModel(string value) { this.value = value; }
        public string Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }
        public override IExpression ToExpression()
        {
            return new StringLiteralExpression(null, value);
        }
    }

    public class VariableValueViewModel : ComparsionValueViewModel
    {
        public VariableValueViewModel(Field field) { }
        public override IExpression ToExpression()
        {
            return null;
        }
    }
    public class ConstantValueViewModel : ComparsionValueViewModel
    {
        public ConstantValueViewModel(Constant constant) { }
        public override IExpression ToExpression()
        {
            return null;
        }
    }
}
