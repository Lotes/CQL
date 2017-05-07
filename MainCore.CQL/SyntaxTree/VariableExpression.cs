using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class VariableExpression: IExpression
    {
        public readonly string Name;

        public VariableExpression(ParserRuleContext context, string name)
        {
            Name = name;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }
    }
}
