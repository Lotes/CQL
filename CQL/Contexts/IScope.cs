using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
    /// <summary>
    /// A scope is a structure containing all accessible variables.
    /// </summary>
    /// <typeparam name="TAbstraction">should be <see cref="System.Type"/> or <see cref="System.Object"/></typeparam>
    /// <typeparam name="TSelf"></typeparam>
    /// <typeparam name="TVariable"></typeparam>
    public interface IScope<TAbstraction, TSelf, TVariable>: IEnumerable<TVariable>
        where TSelf: IScope<TAbstraction, TSelf, TVariable>
        where TVariable: IVariable<TAbstraction>
    {
        /// <summary>
        /// The type system applied to the scope.
        /// </summary>
        ITypeSystem TypeSystem { get; }
        /// <summary>
        /// Searches for a variable in this scope by name.
        /// Returns TRUE and the variable if found, otherwise FALSE
        /// </summary>
        /// <param name="name"></param>
        /// <param name="variable"></param>
        /// <returns></returns>
        bool TryGetVariable(string name, out TVariable variable);
        /// <summary>
        /// Defines oroverwrites a variable.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        TVariable DefineVariable(string name, TAbstraction value);
        /// <summary>
        /// Inherited parent scope. If a requested variable was not found in this scope,
        /// the search continues in the parent scope(s).
        /// </summary>
        TSelf Parent { get; }
        /// <summary>
        /// Returns the value of a given property.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        TAbstraction GetPropertyValue(TAbstraction value, IProperty property);
        /// <summary>
        /// Returns the type of a given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Type GetValueType(TAbstraction value);
    }
}
