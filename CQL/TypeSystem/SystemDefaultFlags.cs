using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Setup flags for the type system initialization.
    /// </summary>
    [Flags]
    public enum SystemDefaultFlags
    {
        /// <summary>
        /// No default behaviour.
        /// </summary>
        None = 0,
        /// <summary>
        /// Add boolean type to the type system.
        /// </summary>
        HasBoolean = 1,
        /// <summary>
        /// Add integer type to the type system.
        /// </summary>
        HasIntegers = 2,
        /// <summary>
        /// Add double type to the type system.
        /// </summary>
        HasDoubles = 4,
        /// <summary>
        /// Add string type to the type system.
        /// </summary>
        HasStrings = 8,
        /// <summary>
        /// Add all default types to the type system.
        /// </summary>
        All = HasBoolean | HasIntegers | HasDoubles | HasStrings
    }
}
