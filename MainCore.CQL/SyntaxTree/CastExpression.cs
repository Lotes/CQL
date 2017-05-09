using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace MainCore.CQL.SyntaxTree
{
    public class CastExpression : IExpression
    {
        public readonly string CastTypeName;
        public readonly IExpression Expression;

        public CastExpression(ParserRuleContext parserContext, string castTypeName, IExpression expression)
        {
            ParserContext = parserContext;
            CastTypeName = castTypeName;
            Expression = expression;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            return $"({CastTypeName})"+Expression.ToString();
        }
    }
}
