using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts.Implementation
{
    public class Scope<T> : IScope<T>
    {
        private Dictionary<string, IVariable<T>> variables = new Dictionary<string, IVariable<T>>();

        public Scope(Scope<T> parent = null)
        {
            Parent = parent;
        }

        public Scope<T> Parent { get; private set; }

        private string Normalize(string str)
        {
            return str.ToUpper();
        }

        public IVariable<T> DefineVariable(string name, T value)
        {
            return variables[Normalize(name)] = new Variable<T>(name, value);
        }

        public bool TryGetVariable(string name, out IVariable<T> variable)
        {
            return variables.TryGetValue(Normalize(name), out variable)
                || (Parent != null && Parent.TryGetVariable(name, out variable));      
        }
    }

    public class Variable<T> : IVariable<T>
    {
        private T value;

        public Variable(string name, T value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public T Value { get; set; }
    }

    public class Context<T>: IContext<T>
    {
        public Context(ITypeSystem typeSystem)
        {
            Scope = new Scope<T>();
            Stack = new Stack<T>();
            TypeSystem = typeSystem;
        }

        public IScope<T> Scope { get; private set; }
        public Stack<T> Stack { get; private set; }
        public ITypeSystem TypeSystem { get; private set; }

        public void PopScope()
        {
            Scope = ((Scope<T>)Scope).Parent;
        }

        public void PushScope()
        {
            Scope = new Scope<T>((Scope<T>)Scope);
        }
    }
}
