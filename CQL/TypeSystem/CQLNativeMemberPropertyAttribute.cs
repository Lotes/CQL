using CQL.SyntaxTree;
using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Marks a class property to be registered as native property for a CQL type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CQLNativeMemberPropertyAttribute : Attribute
    {
        /// <summary>
        /// creates the attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="delimiter"></param>
        public CQLNativeMemberPropertyAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        /// <summary>
        /// Name of the property within the type.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Delimiter to this property.
        /// </summary>
        public IdDelimiter Delimiter { get; private set; }
    }
}
