using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class DecimalLiteralExpression: IExpression
    {
        public readonly double Value;

        public DecimalLiteralExpression(ParserRuleContext context, double value)
        {
            Value = value;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }
    }
}
