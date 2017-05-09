using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class BinaryOperationExpression: IExpression
    {
        public readonly IExpression LeftExpression;
        public readonly IExpression RightExpression;
        public readonly BinaryOperator Operator;

        public BinaryOperationExpression(ParserRuleContext context, BinaryOperator @operator, IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
            Operator = @operator;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            string opString;
            switch(Operator)
            {
                case BinaryOperator.Add: opString = "+"; break;
                case BinaryOperator.And: opString = "&&"; break;
                case BinaryOperator.Contains: opString = "~"; break;
                case BinaryOperator.Div: opString = "/"; break;
                case BinaryOperator.DoesNotContain: opString = "!~"; break;
                case BinaryOperator.Equals: opString = "="; break;
                case BinaryOperator.GreaterThan: opString = ">"; break;
                case BinaryOperator.GreaterThanEquals: opString = ">="; break;
                case BinaryOperator.In: opString = "IN"; break;
                case BinaryOperator.Is: opString = "IS"; break;
                case BinaryOperator.IsNot: opString = "IS NOT"; break;
                case BinaryOperator.LessThan: opString = "<"; break;
                case BinaryOperator.LessThanEquals: opString = "<="; break;
                case BinaryOperator.Mod: opString = "%"; break;
                case BinaryOperator.Mul: opString = "*"; break;
                case BinaryOperator.NotEquals: opString = "!="; break;
                case BinaryOperator.NotIn: opString = "NOT IN"; break;
                case BinaryOperator.Or: opString = "||"; break;
                case BinaryOperator.Sub: opString = "-"; break;
                default: throw new InvalidOperationException("Unhandled operator: "+Operator);
            }
            return $"{LeftExpression.ToString()} {opString} {RightExpression.ToString()}";
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as BinaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.LeftExpression.StructurallyEquals(other.LeftExpression)
                && this.RightExpression.StructurallyEquals(other.RightExpression);
        }
    }
}
