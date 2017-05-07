using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class ParenthesisExpression : IExpression
    {
        public readonly IExpression Expression;

        public ParenthesisExpression(ParserRuleContext context, IExpression expression)
        {
            Expression = expression;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            return $"({Expression.ToString()})";
        }
    }
}
