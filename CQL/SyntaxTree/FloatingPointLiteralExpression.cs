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
    /// AST node representing a decimal number.
    /// </summary>
    public class FloatingPointLiteralExpression: IExpression<FloatingPointLiteralExpression>
    {
        /// <summary>
        /// The actual value.
        /// </summary>
        public readonly double Value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        public FloatingPointLiteralExpression(IParserLocation context, double value)
        {
            Value = value;
            Location = context;
        }

        /// <summary>
        /// Position of the expression in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }
        /// <summary>
        /// Validated type... always double here.
        /// </summary>
        public Type SemanticType { get { return typeof(double); } }

        /// <summary>
        /// Evaluation returning the value.
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
            var other = node as FloatingPointLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        /// <summary>
        /// User-friendly representation as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Validation... nothing to do here.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public FloatingPointLiteralExpression Validate(IValidationScope context)
        {
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
