using System;
using System.Collections.Generic;

namespace MainCore.CQL.Contexts.Implementation
{
    public class FunctionSet : IFunctionSet
    {
        public class Function0Builder<TResult>
        {
            public readonly FunctionSet Parent;
            public readonly string Name;
            public readonly string Usage;
            public Function0Builder(FunctionSet parent, string name, string usage)
            {
                this.Parent = parent;
                this.Name = name;
                this.Usage = usage;
            }
            public Function1Builder<TResult, TArgument1> Parameter<TArgument1>(string name, string usage)
            {
                return new Function1Builder<TResult, TArgument1>(this, new Parameter(name, typeof(TArgument1), usage));
            }
            public void End(Func<TResult> definition)
            {
                Parent.functions.Add(Name.ToLower(), new Function0(Name, typeof(TResult), Usage, () => definition()));
            }
        }

        public class Function1Builder<TResult, TArgument1>
        {
            public readonly Function0Builder<TResult> Parent;
            public readonly Parameter Argument1;

            public Function1Builder(Function0Builder<TResult> parent, Parameter parameter)
            {
                this.Parent = parent;
                this.Argument1 = parameter;
            }

            public Function2Builder<TResult, TArgument1, TArgument2> Parameter<TArgument2>(string name, string usage)
            {
                return new Function2Builder<TResult, TArgument1, TArgument2>(this, new Parameter(name, typeof(TArgument1), usage));
            }

            public void End(Func<TArgument1, TResult> definition)
            {
                Parent.Parent.functions.Add(Parent.Name.ToLower(),
                    new Function1(Parent.Name, typeof(TResult), Parent.Usage, Argument1, a => definition((TArgument1)a)));
            }
        }

        public class Function2Builder<TResult, TArgument1, TArgument2>
        {
            public readonly Function1Builder<TResult, TArgument1> Parent;
            public readonly Parameter Argument2;

            public Function2Builder(Function1Builder<TResult, TArgument1> parent, Parameter parameter)
            {
                this.Parent = parent;
                this.Argument2 = parameter;
            }

            public Function3Builder<TResult, TArgument1, TArgument2, TArgument3> Parameter<TArgument3>(string name, string usage)
            {
                return new Function3Builder<TResult, TArgument1, TArgument2, TArgument3>(this, new Parameter(name, typeof(TArgument3), usage));
            }

            public void End(Func<TArgument1, TArgument2, TResult> definition)
            {
                Parent.Parent.Parent.functions.Add(Parent.Parent.Name.ToLower(),
                    new Function2(Parent.Parent.Name, typeof(TResult), Parent.Parent.Usage, Parent.Argument1, Argument2, (a, b) => definition((TArgument1)a, (TArgument2)b)));
            }
        }

        public class Function3Builder<TResult, TArgument1, TArgument2, TArgument3>
        {
            public readonly Function2Builder<TResult, TArgument1, TArgument2> Parent;
            public readonly Parameter Argument3;

            public Function3Builder(Function2Builder<TResult, TArgument1, TArgument2> parent, Parameter parameter)
            {
                this.Parent = parent;
                this.Argument3 = parameter;
            }

            public void End(Func<TArgument1, TArgument2, TArgument3, TResult> definition)
            {
                Parent.Parent.Parent.Parent.functions.Add(Parent.Parent.Parent.Name.ToLower(),
                    new Function3(Parent.Parent.Parent.Name, typeof(TResult), Parent.Parent.Parent.Usage, Parent.Parent.Argument1, Parent.Argument2, Argument3, (a, b, c) => definition((TArgument1)a, (TArgument2)b, (TArgument3)c)));
            }
        }

        private Dictionary<string, IFunction> functions = new Dictionary<string, IFunction>();

        public Function0Builder<TResult> BeginNew<TResult>(string name, string usage)
        {
            return new Function0Builder<TResult>(this, name, usage);
        }

        public IFunction Get(string name)
        {
            name = name.ToLower();
            if (functions.ContainsKey(name))
                return functions[name];
            return null;
        }
    }
}
