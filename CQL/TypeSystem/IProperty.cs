using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Represents a property of a type.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Name of the property.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Return type of the property.
        /// </summary>
        Type ReturnType { get; }
        /// <summary>
        /// Returns the property for a given THIS value.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        object Get(object @this);
    }
}