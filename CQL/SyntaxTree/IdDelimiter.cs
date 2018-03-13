using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Types of delimiters
    /// </summary>
    public enum IdDelimiter
    {
        /// <summary>
        /// Slash, '/'
        /// </summary>
        Slash,
        /// <summary>
        /// Dot, '.'
        /// </summary>
        Dot,
        /// <summary>
        /// Arrow, '->'
        /// </summary>
        SingleArrow,
        /// <summary>
        /// Hash, '#'
        /// </summary>
        Hash,
        /// <summary>
        /// Dollar, '$'
        /// </summary>
        Dollar
    }
}
