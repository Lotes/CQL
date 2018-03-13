using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Marks a class as CQL type. Classes with this attribute can be scanned by the type system builder <see cref="ITypeSystemBuilder"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CQLTypeAttribute : Attribute
    {
        /// <summary>
        /// Creates an attribute.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        public CQLTypeAttribute(string name, string usage)
        {
            Name = name;
            Usage = usage;
        }
        /// <summary>
        /// Name of the type within the type system
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Usage documentation
        /// </summary>
        public string Usage { get; private set; }
    }
}
