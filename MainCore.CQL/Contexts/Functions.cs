using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public class Parameter
    {
        public readonly Type ParameterType;
        public readonly string Name;
        public readonly string Usage;

        public Parameter(string name, Type parameterType, string usage)
        {
            ParameterType = parameterType;
            Name = name;
            Usage = usage;
        }
    }

    public interface IFunction: INameable
    {
        int Arity { get; }
        Type ResultType { get; }
        object Invoke(params object[] parameters);
        IEnumerable<Parameter> Parameters { get; }
    }

    public abstract class AbstractFunction : IFunction
    {
        public AbstractFunction(int arity, string name, Type resultType, string usage)
        {
            Arity = arity;
            Name = name;
            ResultType = resultType;
            Usage = usage;
        }

        public int Arity { get; private set; }
        public string Name { get; private set; }

        public virtual IEnumerable<Parameter> Parameters { get { return Enumerable.Empty<Parameter>(); } }

        public Type ResultType { get; private set; }
        public string Usage { get; private set; }
        public abstract object Invoke(params object[] parameters);
    }

    public class Function0: AbstractFunction
    {
        public readonly Func<object> Definition;
        public Function0(string name, Type resultType, string usage, Func<object> definition)
            : base(0, name, resultType, usage)
        {
            Definition = definition;
        }

        public override object Invoke(params object[] parameters)
        {
            return Definition();
        }
    }

    public class Function1 : AbstractFunction
    {
        public readonly Parameter Argument1;
        public readonly Func<object, object> Definition;

        public Function1(string name, Type resultType, string usage, Parameter argument1, Func<object, object> definition)
            : base(1, name, resultType, usage)
        {
            Argument1 = argument1;
            Definition = definition;
        }

        public override object Invoke(params object[] parameters)
        {
            return Definition(parameters[0]);
        }

        public override IEnumerable<Parameter> Parameters { get { return new[] { Argument1 }; } }
    }

    public class Function2 : AbstractFunction
    {
        public readonly Parameter Argument1;
        public readonly Parameter Argument2;
        public readonly Func<object, object, object> Definition;

        public Function2(string name, Type resultType, string usage, Parameter argument1, Parameter argument2, Func<object, object, object> definition)
            : base(0, name, resultType, usage)
        {
            Argument1 = argument1;
            Argument2 = argument2;
            Definition = definition;
        }

        public override object Invoke(params object[] parameters)
        {
            return Definition(parameters[0], parameters[1]);
        }

        public override IEnumerable<Parameter> Parameters { get { return new[] { Argument1, Argument2 }; } }
    }

    public class Function3 : AbstractFunction
    {
        public readonly Parameter Argument1;
        public readonly Parameter Argument2;
        public readonly Parameter Argument3;
        public readonly Func<object, object, object, object> Definition;

        public Function3(string name, Type resultType, string usage, Parameter argument1, Parameter argument2, Parameter argument3, Func<object, object, object, object> definition)
            : base(0, name, resultType, usage)
        {
            Argument1 = argument1;
            Argument2 = argument2;
            Argument3 = argument3;
            Definition = definition;
        }

        public override object Invoke(params object[] parameters)
        {
            return Definition(parameters[0], parameters[1], parameters[2]);
        }

        public override IEnumerable<Parameter> Parameters { get { return new[] { Argument1, Argument2, Argument3 }; } }
    }
}
