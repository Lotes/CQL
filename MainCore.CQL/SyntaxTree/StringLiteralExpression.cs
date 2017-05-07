using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class StringLiteralExpression: IExpression
    {
        public readonly string Value;

        public StringLiteralExpression(ParserRuleContext context, string value)
        {
            Value = value;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            return $"\"{Value.Escape()}\"";
        }
    }
}
