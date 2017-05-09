using Antlr4.Runtime;
using System;

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

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as StringLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return $"\"{Value.Escape()}\"";
        }
    }
}
