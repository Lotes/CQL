using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class UnaryOperationExpression: IExpression
    {
        public readonly IExpression Expression;
        public readonly UnaryOperator Operator;

        public UnaryOperationExpression(ParserRuleContext context, UnaryOperator @operator, IExpression expression)
        {
            Expression = expression;
            Operator = @operator;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as UnaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            string opStr;
            switch(Operator)
            {
                case UnaryOperator.Minus: opStr = "-"; break;
                case UnaryOperator.Plus: opStr = "+"; break;
                case UnaryOperator.Not: opStr = "!"; break;
                default: throw new InvalidOperationException($"Unhandled operator: {Operator}");
            }
            return $"{opStr}{Expression.ToString()}";
        }
    }
}
