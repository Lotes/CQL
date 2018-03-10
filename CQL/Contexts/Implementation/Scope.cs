using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CQL.Contexts.Implementation
{
    public class ValidationScope : Scope<Type>
    {
        public ValidationScope(ITypeSystem system, IScope<Type> parent = null) : base(system, parent)
        {
        }

        protected override Type GetPropertyValue(Type value, IProperty property)
        {
            return property.ReturnType;
        }

        protected override Type GetValueType(Type value)
        {
            return value;
        }
    }

    public class EvaluationScope : Scope<object>
    {
        public EvaluationScope(ITypeSystem system, IScope<object> parent = null) : base(system, parent)
        {

        }

        protected override object GetPropertyValue(object value, IProperty property)
        {
            return property.Get(value);
        }

        protected override Type GetValueType(object value)
        {
            return value.GetType();
        }
    }

    public abstract class Scope<T> : IScope<T>
    {
        private ITypeSystem system;
        private Dictionary<string, IVariable<T>> variables = new Dictionary<string, IVariable<T>>();
        private Dictionary<string, IVariable<T>> thisMembers = new Dictionary<string, IVariable<T>>();

        public Scope(ITypeSystem system, IScope<T> parent = null)
        {
            this.system = system;
            Parent = parent;
        }

        public IScope<T> Parent { get; private set; }

        public ITypeSystem TypeSystem
        {
            get
            {
                return system;
            }
        }

        private string Normalize(string str)
        {
            return str.ToUpper();
        }

        public IVariable<T> DefineVariable(string name, T value)
        {
            var normalizedName = Normalize(name);
            var variable = variables[normalizedName] = new Variable<T>(name, value);
            if(normalizedName == Normalize(ScopeExtensions.ThisName))
            {
                thisMembers.Clear();
                var cqlType = system.GetTypeByNative(GetValueType(variable.Value));
                foreach(var property in cqlType.Members)
                {
                    thisMembers.Add(Normalize(property.Name), new Variable<T>(property.Name, GetPropertyValue(value, property)));
                }
            }
            return variable;
        }

        protected abstract T GetPropertyValue(T value, IProperty property);

        protected abstract Type GetValueType(T value);

        public bool TryGetVariable(string name, out IVariable<T> variable)
        {
            name = Normalize(name);
            return thisMembers.TryGetValue(name, out variable)
                || variables.TryGetValue(name, out variable)
                || (Parent != null && Parent.TryGetVariable(name, out variable));      
        }

        public IEnumerator<IVariable<T>> GetEnumerator()
        {
            return thisMembers.Values.Union(variables.Values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
