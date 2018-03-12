using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Represents the top-level boolean expression.
    /// </summary>
    public class Query: ISyntaxTreeNode<Query>
    {
        /// <summary>
        /// Queries expression. Must be boolean.
        /// </summary>
        public IExpression Expression { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expression">not null</param>
        public Query(IParserLocation context, IExpression expression)
        {
            Location = context;
            Expression = expression;
        }

        /// <summary>
        /// Position in the user query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as Query;
            if (other == null)
                return false;
            return this.Expression.StructurallyEquals(other.Expression);
        }

        /// <summary>
        /// AST to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Expression.ToString();
        }

        /// <summary>
        /// Validates the query. If the expression is not boolean, throws a <see cref="LocateableException"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Query Validate(IValidationScope context)
        {
            Expression = Expression.Validate(context);
            if (Expression.SemanticType != typeof(bool))
                throw new LocateableException(Expression.Location, "Query expression type must be boolean!");
            return this;
        }

        /// <summary>
        /// Evaluates the query.
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public bool Evaluate(IEvaluationScope subject)
        {
            return (bool)Expression.Evaluate(subject);
        }
    }
}
