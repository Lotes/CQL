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
    }
}
