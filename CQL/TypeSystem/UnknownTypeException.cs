using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Exception for types that are not in a given type system.
    /// </summary>
    public class UnknownTypeException: Exception
    {
        /// <summary>
        /// The unknown type.
        /// </summary>
        public readonly Type UnknownType;
        /// <summary>
        /// Creates a exception.
        /// </summary>
        /// <param name="type"></param>
        public UnknownTypeException(Type type) : base("This type is unknown to the given type system!")
        {
            UnknownType = type;
        }
    }
}
