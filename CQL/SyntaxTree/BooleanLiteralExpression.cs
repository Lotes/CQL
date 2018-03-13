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
    /// Expression representing boolean constants.
    /// </summary>
    public class BooleanLiteralExpression: IExpression<BooleanLiteralExpression>
    {
        /// <summary>
        /// The actual value, true or false.
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Creates a AST node for boolean literal.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        public BooleanLiteralExpression(IParserLocation context, bool value)
        {
            Value = value;
            Location = context;
        }

        /// <summary>
        /// The position of the literal in the user query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// The type of a boolean literal (is always typeof(bool)).
        /// </summary>
        public Type SemanticType { get { return typeof(bool); } }

        /// <summary>
        /// Evaluates literal to its value.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return Value;
        }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as BooleanLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        /// <summary>
        /// AST to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Validates literal.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public BooleanLiteralExpression Validate(IValidationScope context)
        {
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
