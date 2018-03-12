using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Flags for manually adding types to a type system. These flags represents 
    /// groups of operators which will be added automatically.
    /// </summary>
    [Flags]
    public enum TypeDefaultFlags
    {
        /// <summary>
        /// No automatic type operations.
        /// </summary>
        None = 0,
        /// <summary>
        /// Add Equals (=, !=) operators
        /// </summary>
        Equals = 1,
        /// <summary>
        /// Add CompareTo operators, if is defined on given type.
        /// </summary>
        Comparable = 2,
        /// <summary>
        /// Add numeric operations (+,-,/,*,%), if type is numeric.
        /// </summary>
        Numeric = 4,
        /// <summary>
        /// Try to add all default operations if possible.
        /// </summary>
        All = Equals | Comparable | Numeric 
    }
}
