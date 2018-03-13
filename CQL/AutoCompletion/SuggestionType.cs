using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// Types of suggestion answers
    /// </summary>
    public enum SuggestionType
    {
        /// <summary>
        /// Operators
        /// </summary>
        Token,
        /// <summary>
        /// Variable names
        /// </summary>
        Variable,
        /// <summary>
        /// Function names
        /// </summary>
        Function,
        /// <summary>
        /// Type names
        /// </summary>
        Type
    }
}
