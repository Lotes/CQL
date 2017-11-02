using GalaSoft.MvvmLight;
using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
using MainCore.CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public enum FieldComparsionState
    {
        Phase1_FieldMissing,
        Phase2_OperatorMissing,
        Phase3_ValueMissing,
        ReadyToUse
    }

    public class FieldComparsionViewModel : QueryPartViewModel
    {
        private FieldComparsionState state;
        private Field field;
        private IContext context;
        private BinaryOperator? op;
        private ComparsionValueViewModel value;
        private Dictionary<Type, Dictionary<Type, HashSet<BinaryOperation>>> binaryOperations = new Dictionary<Type, Dictionary<Type, HashSet<BinaryOperation>>>();
        public FieldComparsionViewModel(IContext context, Field field, BinaryOperator? op = null, ComparsionValueViewModel value = null)
        {
            this.context = context;
            this.field = field;
            this.op = op;
            this.value = value;
            this.state = field == null
                ? FieldComparsionState.Phase1_FieldMissing
                : op == null
                    ? FieldComparsionState.Phase2_OperatorMissing
                    : value == null
                        ? FieldComparsionState.Phase3_ValueMissing
                        : FieldComparsionState.ReadyToUse;
            ComputePossibleStates();
            UpdateField();
        }

        private void ComputePossibleStates()
        {
            PossibleFields = new ObservableCollection<Field>();
            PossibleOperators = new ObservableCollection<BinaryOperator>();
            PossibleValues = new ObservableCollection<ComparsionValueViewModel>();
            
            var typeSystem = context.TypeSystem;
            var operations = typeSystem.GetBinaryOperations().Where(o => o.ResultType == typeof(bool));
            foreach(var operation in operations)
            {
                var lhss = new[] { operation.LeftType }.Concat(typeSystem.GetImplicitlyCastsTo(operation.LeftType));
                var rhss = new[] { operation.RightType }.Concat(typeSystem.GetImplicitlyCastsTo(operation.RightType));
                foreach (var lhs in lhss)
                    binaryOperations.GetOrLazyInsert(lhs, () => new Dictionary<Type, HashSet<BinaryOperation>>())
                        .GetOrLazyInsert(operation.RightType, () => new HashSet<BinaryOperation>())
                        .Add(operation);
                foreach (var rhs in rhss)
                    binaryOperations.GetOrLazyInsert(operation.LeftType, () => new Dictionary<Type, HashSet<BinaryOperation>>())
                        .GetOrLazyInsert(rhs, () => new HashSet<BinaryOperation>())
                        .Add(operation);
            }
        }

        public FieldComparsionState State { get { return state; } set { state = value; RaisePropertyChanged(() => State); } }

        public Field Field { get { return field; } set { field = value;  RaisePropertyChanged(() => Field); UpdateOperator(); } }
        public BinaryOperator? Operator { get { return op; } set { op = value; RaisePropertyChanged(() => Operator); UpdateValue(); } }
        public ComparsionValueViewModel Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }

        public ObservableCollection<Field> PossibleFields { get; private set; }
        public ObservableCollection<BinaryOperator> PossibleOperators { get; private set; }
        public ObservableCollection<ComparsionValueViewModel> PossibleValues { get; private set; }

        private void UpdateField()
        {
            PossibleFields.Clear();
            PossibleOperators.Clear();
            PossibleValues.Clear();

            foreach (var field in context.Fields)
                PossibleFields.Add(field);

            UpdateOperator();
        }

        private void UpdateOperator()
        {
            PossibleOperators.Clear();
            PossibleValues.Clear();

            var lhsType = Field.FieldType;
            Dictionary<Type, HashSet<BinaryOperation>> ops;
            if (binaryOperations.TryGetValue(lhsType, out ops))
                foreach (var op in ops.Values.SelectMany(bos => bos).Select(bo => bo.Operator).Distinct())
                    PossibleOperators.Add(op);
            if (PossibleOperators.Contains(BinaryOperator.Equals))
                Operator = BinaryOperator.Equals;
            else if(PossibleOperators.Any())
                Operator = PossibleOperators.First();

            UpdateValue();
        }

        private void UpdateValue()
        {
            PossibleValues.Clear();


        }

        public override IExpression ToExpression()
        {
            return (field == null || op == null || !op.HasValue || value == null)
                ? (IExpression)new BooleanLiteralExpression(null, true) 
                : (IExpression)new BinaryOperationExpression(null, op.Value,
                    new MultiIdExpression(null, field.Name),
                    value.ToExpression());
        }

        public override FilterBoxState Validate(IContext context)
        {
            return field == null || op == null || !op.HasValue || value == null ? FilterBoxState.HasErrors : FilterBoxState.ReadyToUse;
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
