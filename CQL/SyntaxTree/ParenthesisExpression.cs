using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// AST node representing a parenthesed expression (is important to transform back to a string!).
    /// </summary>
    public class ParenthesisExpression : IExpression<ParenthesisExpression>
    {
        /// <summary>
        /// Inner expression.
        /// </summary>
        public IExpression Expression { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expression"></param>
        public ParenthesisExpression(IParserLocation context, IExpression expression)
        {
            Expression = expression;
            Location = context;
            SemanticType = null;
        }

        /// <summary>
        /// Position in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Validated type
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ParenthesisExpression;
            if (other == null)
                return false;
            return Expression.StructurallyEquals(other.Expression);
        }

        /// <summary>
        /// User-friendly representation of this expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"({Expression.ToString()})";
        }

        /// <summary>
        /// Validation...
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ParenthesisExpression Validate(IValidationScope context)
        {
            Expression = Expression.Validate(context);
            SemanticType = Expression.SemanticType;
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Evaluation...
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return Expression.Evaluate(context);
        }
    }
}
