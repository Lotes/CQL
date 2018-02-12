using Antlr4.Runtime;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.ErrorHandling
{
    public class LocateableException: Exception
    {
        public readonly int StartIndex;
        public readonly int Length;

        public LocateableException(IParserLocation location, string message, Exception innerException = null)
            : this(location != null ? location.StartIndex : 0, location != null ? location.StopIndex : 0, message, innerException)
        {

        }

        public LocateableException(int startIndex, int endIndex, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StartIndex = startIndex;
            Length = endIndex - startIndex + 1;
        }
    }
}
