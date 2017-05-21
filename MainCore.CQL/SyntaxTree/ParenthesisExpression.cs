using Antlr4.Runtime;
using System;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class ParenthesisExpression : IExpression<ParenthesisExpression>
    {
        public IExpression Expression { get; private set; }

        public ParenthesisExpression(ParserRuleContext context, IExpression expression)
        {
            Expression = expression;
            ParserContext = context;
            SemanticType = null;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"({Expression.ToString()})";
        }

        public ParenthesisExpression Validate(IContext context)
        {
            Expression = Expression.Validate(context);
            SemanticType = Expression.SemanticType;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
