using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class ConditionalExpression: IExpression
    {
        public readonly IExpression Condition;
        public readonly IExpression Then;
        public readonly IExpression Else;

        public ConditionalExpression(ParserRuleContext context, IExpression condition, IExpression then, IExpression @else)
        {
            Condition = condition;
            Then = then;
            Else = @else;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            return $"{Condition.ToString()} ? {Then.ToString()} : {Else.ToString()}";
        }
    }
}
