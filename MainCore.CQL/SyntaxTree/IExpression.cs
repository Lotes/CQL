using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public interface IExpression
    {
        ParserRuleContext ParserContext { get; }
        //bool StructurallyEquals(IExpression other);
    }
}
