using CQL.SyntaxTree;
using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Marks a member function to be registered in the type system builder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CQLNativeMemberFunctionAttribute : Attribute
    {
        /// <summary>
        /// Creates the attribute
        /// </summary>
        /// <param name="name"></param>
        /// <param name="delimiter"></param>
        public CQLNativeMemberFunctionAttribute(string name, IdDelimiter delimiter)
        {
            Name = name;
            Delimiter = delimiter;
        }
        /// <summary>
        /// Name of the method within the type system.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The delimiter to access the method.
        /// </summary>
        public IdDelimiter Delimiter { get; private set; }
    }
}
