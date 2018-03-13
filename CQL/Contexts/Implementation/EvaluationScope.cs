using CQL.TypeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CQL.Contexts.Implementation
{
    /// <summary>
    /// Default implementation of <see cref="IEvaluationScope"/>
    /// </summary>
    public class EvaluationScope : IEvaluationScope
    {
        private ITypeSystem system;
        private Dictionary<string, IVariableDefinition> variables = new Dictionary<string, IVariableDefinition>();
        private Dictionary<string, IVariableDefinition> thisMembers = new Dictionary<string, IVariableDefinition>();

        /// <summary>
        /// Creates an empty evaluation scope.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="parent"></param>
        public EvaluationScope(ITypeSystem system, IEvaluationScope parent = null)
        {
            this.system = system;
            Parent = parent;
        }

        /// <summary>
        /// Get the property value of a THIS value.
        /// </summary>
        /// <param name="value">THIS</param>
        /// <param name="property"></param>
        /// <returns></returns>
        public object GetPropertyValue(object value, IProperty property)
        {
            return property.Get(value);
        }

        /// <summary>
        /// Get the type of a value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Type GetValueType(object value)
        {
            return value.GetType();
        }

        /// <summary>
        /// Parent of the scope. If a lookup in this scope fails, search continues in the parent scope.
        /// </summary>
        public IEvaluationScope Parent { get; private set; }

        /// <summary>
        /// The typesystem applied to this scope.
        /// </summary>
        public ITypeSystem TypeSystem
        {
            get
            {
                return system;
            }
        }

        /// <summary>
        /// Defines a variable in this scope.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IVariableDefinition DefineVariable(string name, object value)
        {
            var normalizedName = ScopeExtensions.NormalizeVariableName(name);
            var variable = variables[normalizedName] = new VariableDefinition(name, value);
            if (normalizedName == ScopeExtensions.NormalizeVariableName(ScopeExtensions.ThisName))
            {
                thisMembers.Clear();
                var cqlType = system.GetTypeByNative(GetValueType(variable.Value));
                foreach (var property in cqlType.Members)
                {
                    thisMembers.Add(ScopeExtensions.NormalizeVariableName(property.Name), new VariableDefinition(property.Name, GetPropertyValue(value, property)));
                }
            }
            return variable;
        }
        
        /// <summary>
        /// Lookups a variable in this and parent scopes. Returns TRUE and a variable if found, FALSE otherwise.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool TryGetVariable(string name, out IVariableDefinition variable)
        {
            name = ScopeExtensions.NormalizeVariableName(name);
            return thisMembers.TryGetValue(name, out variable)
                || variables.TryGetValue(name, out variable)
                || (Parent != null && Parent.TryGetVariable(name, out variable));
        }

        /// <summary>
        /// Enumerator over this scope.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IVariableDefinition> GetEnumerator()
        {
            return thisMembers.Values.Union(variables.Values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
