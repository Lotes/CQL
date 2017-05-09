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

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as CastExpression;
            if (other == null)
                return false;
            return this.CastTypeName == other.CastTypeName
                && this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            return $"({CastTypeName})"+Expression.ToString();
        }
    }
}
