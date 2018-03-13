using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Kind of coercion rules
    /// </summary>
    public enum CoercionKind
    {
        /// <summary>
        /// Implicit rules can be called during the validation process. New AST node could be included during this step.
        /// </summary>
        Implicit,
        /// <summary>
        /// Explicit rules can only be used by writing a type name between two parentheses.
        /// </summary>
        Explicit
    }
}
