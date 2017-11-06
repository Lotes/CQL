using System;
using CQL.TypeSystem;
using System.Collections.Generic;
using System.Diagnostics;

namespace CQL.Contexts.Implementation
{
    public class ContextBuilder : IContextBuilder
    {
        private ITypeSystem typeSystem;
        private Dictionary<string, INameable> @namespace = new Dictionary<string, INameable>();

        public ContextBuilder(ITypeSystem typeSystem)
        {
            this.typeSystem = typeSystem;
        }

        private string NormalizeName(string name)
        {
            return name.ToLower();
        }

        private void AddToNamespace(INameable nameable)
        {
            @namespace.Add(NormalizeName(nameable.Name), nameable);
        }

        public void AddConstant<THost, TField>(string name, string usage, Func<THost, TField> getter)
        {
            AddToNamespace(new Constant(name, usage, typeof(THost), typeof(TField), a => (object)getter((THost)a)));
            Debug.WriteLine($"- added constant '{name}: {typeof(TField).Name}'");
        }

        public void AddField<THost, TField>(string name, string usage, Func<THost, TField> getter, Func<THost, bool> isNull)
        {
            AddToNamespace(new Field(name, usage, typeof(THost), typeof(TField), h => getter((THost)h), h => isNull((THost)h)));
            Debug.WriteLine($"- added field '{name}: {typeof(THost).Name}/{typeof(TField).Name}'");
        }

        public Function0Builder<TResult> BeginFunction<TResult>(string name, string usage)
        {
            return new Function0Builder<TResult>(AddToNamespace, name, usage);
        }

        public IContext Build()
        {
            return new Context(typeSystem, @namespace);
        }

        public class Function0Builder<TResult>
        {
            public readonly Action<INameable> AddToNamespace;
            public readonly string Name;
            public readonly string Usage;
            public Function0Builder(Action<INameable> addToNamespace, string name, string usage)
            {
                this.AddToNamespace = addToNamespace;
                this.Name = name;
                this.Usage = usage;
            }
            public Function1Builder<TResult, TArgument1> Parameter<TArgument1>(string name, string usage)
            {
                return new Function1Builder<TResult, TArgument1>(this, new Parameter(name, typeof(TArgument1), usage));
            }
            public void End(Func<TResult> definition)
            {
                AddToNamespace(new Function0(Name, typeof(TResult), Usage, () => definition()));
                Debug.WriteLine($"- added function '{Name}()'");
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
                Parent.AddToNamespace(new Function1(Parent.Name, typeof(TResult), Parent.Usage, Argument1, a => definition((TArgument1)a)));
                Debug.WriteLine($"- added function '{Parent.Name}({Argument1.Name})'");
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
                Parent.Parent.AddToNamespace(new Function2(Parent.Parent.Name, typeof(TResult), Parent.Parent.Usage, Parent.Argument1, Argument2, (a, b) => definition((TArgument1)a, (TArgument2)b)));
                Debug.WriteLine($"- added function '{Parent.Parent.Name}({Parent.Argument1.Name}, {Argument2.Name})'");
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
                Parent.Parent.Parent.AddToNamespace(new Function3(Parent.Parent.Parent.Name, typeof(TResult), Parent.Parent.Parent.Usage, Parent.Parent.Argument1, Parent.Argument2, Argument3, (a, b, c) => definition((TArgument1)a, (TArgument2)b, (TArgument3)c)));
                Debug.WriteLine($"- added function '{Parent.Parent.Parent.Name}({Parent.Parent.Argument1.Name}, {Parent.Argument2.Name}, {Argument3.Name})'");
            }
        }
    }
}
