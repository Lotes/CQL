using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
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
            var other = node as ParenthesisExpression;
            if (other == null)
                return false;
            return Expression.StructurallyEquals(other.Expression);
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

        public object Evaluate<TSubject>(TSubject subject)
        {
            return Expression.Evaluate(subject);
        }
    }
}
