using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// AST node representing a string literal.
    /// </summary>
    public class StringLiteralExpression: IExpression<StringLiteralExpression>
    {
        /// <summary>
        /// Actual value of the literal (unescaped).
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        public StringLiteralExpression(IParserLocation context, string value)
        {
            Value = value;
            Location = context;
        }

        /// <summary>
        /// Location of this literal in query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// The validated type... always System.String
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Evaluation by returning the string value.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return Value;
        }

        /// <summary>
        /// Deep equals
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as StringLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        /// <summary>
        /// Escaped string literal.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"\"{Value.Escape()}\"";
        }

        /// <summary>
        /// Validation, nothing important for strings.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public StringLiteralExpression Validate(IValidationScope context)
        {
            SemanticType = typeof(string);
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
