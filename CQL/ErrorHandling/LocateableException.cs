using Antlr4.Runtime;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.ErrorHandling
{
    /// <summary>
    /// Exception with positional information. Where in the user query was an error detected?
    /// </summary>
    public class LocateableException: Exception
    {
        /// <summary>
        /// first character index
        /// </summary>
        public readonly int StartIndex;
        /// <summary>
        /// Length of the errornous piece of code.
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// Creates a exception using a <see cref="IParserLocation"/>
        /// </summary>
        /// <param name="location"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LocateableException(IParserLocation location, string message, Exception innerException = null)
            : this(location != null ? location.StartIndex : 0, location != null ? location.StopIndex : 0, message, innerException)
        {

        }

        /// <summary>
        /// Creates an exception using the start and end character index.
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LocateableException(int startIndex, int endIndex, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StartIndex = startIndex;
            Length = endIndex - startIndex + 1;
        }
    }
}
