using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public class ParenthesisExpression : IExpression<ParenthesisExpression>
    {
        public IExpression Expression { get; private set; }

        public ParenthesisExpression(IParserLocation context, IExpression expression)
        {
            Expression = expression;
            Location = context;
            SemanticType = null;
        }

        public IParserLocation Location { get; private set; }

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

        public ParenthesisExpression Validate(IScope<Type> context)
        {
            Expression = Expression.Validate(context);
            SemanticType = Expression.SemanticType;
            return this;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public object Evaluate(IScope<object> context)
        {
            return Expression.Evaluate(context);
        }
    }
}
