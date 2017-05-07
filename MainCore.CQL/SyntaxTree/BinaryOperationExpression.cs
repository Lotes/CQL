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
    }
}
