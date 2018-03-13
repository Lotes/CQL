using CQL.TypeSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CQL.Contexts.Implementation
{
    /// <summary>
    /// Default implementation of <see cref="IValidationScope"/>
    /// </summary>
    public class ValidationScope : IValidationScope
    {
        private Dictionary<string, IVariableDeclaration> variables = new Dictionary<string, IVariableDeclaration>();
        private Dictionary<string, IVariableDeclaration> thisMembers = new Dictionary<string, IVariableDeclaration>();

        /// <summary>
        /// Creates an empty validation scope.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="parent"></param>
        public ValidationScope(ITypeSystem system, IValidationScope parent = null)
        {
            this.Parent = parent;
            this.TypeSystem = system;
        }

        /// <summary>
        /// Returns the applied type system.
        /// </summary>
        public ITypeSystem TypeSystem { get; private set; }

        /// <summary>
        /// Returns the optional parent scope (can be null).
        /// </summary>
        public IValidationScope Parent { get; private set; }

        /// <summary>
        /// Defines a variable with name and type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IVariableDeclaration DefineVariable(string name, Type value)
        {
            var normalizedName = ScopeExtensions.NormalizeVariableName(name);
            var variable = variables[normalizedName] = new VariableDeclaration(name, value);
            if (normalizedName == ScopeExtensions.NormalizeVariableName(ScopeExtensions.ThisName))
            {
                thisMembers.Clear();
                var cqlType = TypeSystem.GetTypeByNative(GetValueType(variable.Value));
                foreach (var property in cqlType.Members)
                {
                    thisMembers.Add(ScopeExtensions.NormalizeVariableName(property.Name), new VariableDeclaration(property.Name, GetPropertyValue(value, property)));
                }
            }
            return variable;
        }

        /// <summary>
        /// Returns variable enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IVariableDeclaration> GetEnumerator()
        {
            return thisMembers.Values.Union(variables.Values).GetEnumerator();
        }

        /// <summary>
        /// Returns the type of a property.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public Type GetPropertyValue(Type value, IProperty property)
        {
            return property.ReturnType;
        }

        /// <summary>
        /// Returns the type itself...
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Type GetValueType(Type value)
        {
            return value;
        }

        /// <summary>
        /// Lookups for a variable definition. If variable exists returns TRUE and the variable, otherwise FALSE.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool TryGetVariable(string name, out IVariableDeclaration variable)
        {
            name = ScopeExtensions.NormalizeVariableName(name);
            return thisMembers.TryGetValue(name, out variable)
                || variables.TryGetValue(name, out variable)
                || (Parent != null && Parent.TryGetVariable(name, out variable));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
