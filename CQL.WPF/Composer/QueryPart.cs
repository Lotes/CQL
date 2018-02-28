using GalaSoft.MvvmLight;
using CQL.Contexts;
using CQL.SyntaxTree;
using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace CQL.WPF.Composer
{
    public abstract class QueryPartViewModel: ViewModelBase
    {
        public abstract IExpression ToExpression();
        public abstract FilterBoxState Validate(IScope<Type> context);
        public event EventHandler ReadyModeRequested;
        protected void RequestReadyMode() { ReadyModeRequested?.Invoke(this, new EventArgs()); }
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
        private IVariable<Type> field;
        private IScope<Type> context;
        private BinaryOperator? op;
        private ComparsionValueViewModel value;
        private Dictionary<Type, Dictionary<Type, HashSet<BinaryOperation>>> binaryOperations = new Dictionary<Type, Dictionary<Type, HashSet<BinaryOperation>>>();
        public FieldComparsionViewModel(IScope<Type> context, IVariable<Type> field, BinaryOperator? op = null, ComparsionValueViewModel value = null)
        {
            this.KeyDownCommand = new RelayCommand<KeyEventArgs>(args => 
            {
                if (args.Key == Key.Return || args.Key == Key.Enter)
                    RequestReadyMode();
            });
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

        public RelayCommand<KeyEventArgs> KeyDownCommand { get;  private set; }

        private void ComputePossibleStates()
        {
            PossibleFields = new ObservableCollection<IVariable<Type>>();
            PossibleOperators = new ObservableCollection<BinaryOperator>();
            
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

        public IVariable<Type> Field { get { return field; } set { field = value;  RaisePropertyChanged(() => Field); UpdateOperator(); } }
        public BinaryOperator? Operator { get { return op; } set { op = value; RaisePropertyChanged(() => Operator); UpdateValue(); } }
        public ComparsionValueViewModel Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); } }

        public ObservableCollection<IVariable<Type>> PossibleFields { get; private set; }
        public ObservableCollection<BinaryOperator> PossibleOperators { get; private set; }

        private void UpdateField()
        {
            PossibleFields.Clear();
            PossibleOperators.Clear();

            foreach (var field in context)
                PossibleFields.Add(field);

            if (Field != null)
                State = FieldComparsionState.Phase2_OperatorMissing;

            UpdateOperator();
        }

        private void UpdateOperator()
        {
            PossibleOperators.Clear();

            var lhsType = Field.Value;
            Dictionary<Type, HashSet<BinaryOperation>> ops;
            if (binaryOperations.TryGetValue(lhsType, out ops))
                foreach (var op in ops.Values.SelectMany(bos => bos).Select(bo => bo.Operator).Distinct())
                    PossibleOperators.Add(op);
            if(Operator == null || !Operator.HasValue)
            {
                if (PossibleOperators.Contains(BinaryOperator.Equals))
                    Operator = BinaryOperator.Equals;
                else if (PossibleOperators.Any())
                    Operator = PossibleOperators.First();
            }

            if (State == FieldComparsionState.Phase2_OperatorMissing && Operator != null && Operator.HasValue)
                State = FieldComparsionState.Phase3_ValueMissing;

            UpdateValue();
        }

        private void UpdateValue()
        {
            if(Field != null && Operator != null)
            {
                Dictionary<Type, HashSet<BinaryOperation>> byRhs;
                if(binaryOperations.TryGetValue(Field.Value, out byRhs))
                {
                    foreach (var rhs in byRhs.Keys.ToArray())
                        if (!byRhs[rhs].Any(operation => operation.Operator == Operator))
                            byRhs.Remove(rhs);
                    var possibleValues = new List<ComparsionValueViewModel>();
                    if (byRhs.Keys.Contains(typeof(bool)))
                        possibleValues.Add(new BooleanLiteralValueViewModel(true));
                    if (byRhs.Keys.Contains(typeof(double)))
                        possibleValues.Add(new DecimalLiteralValueViewModel(0));
                    if (byRhs.Keys.Contains(typeof(string)))
                        possibleValues.Add(new StringLiteralValueViewModel(""));
                    if (Value == null && possibleValues.Any())
                        Value = possibleValues.First();
                }
            }

            if (State == FieldComparsionState.Phase3_ValueMissing && Value != null)
                State = FieldComparsionState.ReadyToUse;
        }

        public override IExpression ToExpression()
        {
            return (field == null || op == null || !op.HasValue || value == null)
                ? (IExpression)new BooleanLiteralExpression(null, true) 
                : (IExpression)new BinaryOperationExpression(null, op.Value,
                    new VariableExpression(null, field.Name),
                    value.ToExpression());
        }

        public override FilterBoxState Validate(IScope<Type> context)
        {
            return field == null || op == null || !op.HasValue || value == null ? FilterBoxState.HasErrors : FilterBoxState.ReadyToUse;
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
                RequestReadyMode();
            }
        }

        public override IExpression ToExpression()
        {
            return new BooleanLiteralExpression(null, value);
        }

        public override FilterBoxState Validate(IScope<Type> context)
        {
            return FilterBoxState.ReadyToUse;
        }
    }

    public abstract class ComparsionValueViewModel: ViewModelBase
    {
        protected abstract string GetText();
        public string Text { get { return GetText(); } }
        public abstract Type PreferredType { get; }
        public abstract IExpression ToExpression();
    }

    public class BooleanLiteralValueViewModel : ComparsionValueViewModel
    {
        private bool value;
        public BooleanLiteralValueViewModel(bool value)
        {
            this.value = value;
        }

        public override Type PreferredType
        {
            get
            {
                return typeof(bool);
            }
        }

        public bool Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); RaisePropertyChanged(() => Text); } }
        public override IExpression ToExpression()
        {
            return new BooleanLiteralExpression(null, value);
        }

        protected override string GetText()
        {
            return value ? "True" : "False";
        }
    }
    public class DecimalLiteralValueViewModel : ComparsionValueViewModel
    {
        private double value;
        public DecimalLiteralValueViewModel(double value) { this.value = value; }
        public double Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); RaisePropertyChanged(() => Text); } }
        public override IExpression ToExpression()
        {
            return new FloatingPointLiteralExpression(null, value);
        }

        protected override string GetText()
        {
            return value.ToString();
        }

        public override Type PreferredType
        {
            get
            {
                return typeof(double);
            }
        }
    }
    public class StringLiteralValueViewModel : ComparsionValueViewModel
    {
        private string value;
        public StringLiteralValueViewModel(string value) { this.value = value; }
        public string Value { get { return value; } set { this.value = value; RaisePropertyChanged(() => Value); RaisePropertyChanged(() => Text); } }
        public override IExpression ToExpression()
        {
            return new StringLiteralExpression(null, value);
        }

        protected override string GetText()
        {
            return "\""+value.Escape()+"\"";
        }

        public override Type PreferredType
        {
            get
            {
                return typeof(string);
            }
        }
    }

    [ValueConversion(typeof(ComparsionValueViewModel), typeof(string))]
    public class ComparsionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is StringLiteralValueViewModel)
                return (value as StringLiteralValueViewModel).Value;
            if (value is DecimalLiteralValueViewModel)
                return (value as DecimalLiteralValueViewModel).Value.ToString();
            if (value is StringLiteralValueViewModel)
                return (value as BooleanLiteralValueViewModel).Value.ToString();
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as string;
            var type = parameter as Type;
            bool boolResult;
            if (type == typeof(bool) && bool.TryParse(str, out boolResult))
                return new BooleanLiteralValueViewModel(boolResult);
            double decimalResult;
            if (type == typeof(double) && double.TryParse(str, out decimalResult))
                return new DecimalLiteralValueViewModel(decimalResult);
            if(type == typeof(string))
                return new StringLiteralValueViewModel(str);
            throw new InvalidOperationException("Something is wrong here...");
        }
    }
}
