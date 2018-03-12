using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// This exception describes the situation when a native type was resolved with more than one type in the type system.
    /// </summary>
    public class AmbigiousTypeException: Exception
    {
        /// <summary>
        /// The requested type.
        /// </summary>
        public readonly Type GivenType;
        /// <summary>
        /// The resolved types.
        /// </summary>
        public readonly IEnumerable<IType> KnownTypes;
        /// <summary>
        /// Creates the exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="knownTypes"></param>
        public AmbigiousTypeException(Type type, IEnumerable<IType> knownTypes) : base("Multiple type choices are possible for the requested type.")
        {
            GivenType = type;
            KnownTypes = knownTypes.ToArray();
        }
    }
}
