using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class BooleanLiteralExpression: IExpression
    {
        public readonly bool Value;

        public BooleanLiteralExpression(ParserRuleContext context, bool value)
        {
            Value = value;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
