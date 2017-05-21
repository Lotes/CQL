using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public static class SyntaxTreeExtensions
    {
        public static bool WasValidated(this IExpression @this) { return @this.SemanticType != null; }
    }
}
