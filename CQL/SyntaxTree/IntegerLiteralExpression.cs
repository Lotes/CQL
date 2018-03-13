using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Represents an integer literal.
    /// </summary>
    public class IntegerLiteralExpression : IExpression<IntegerLiteralExpression>
    {
        /// <summary>
        /// The actual value.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        public IntegerLiteralExpression(IParserLocation context, int value)
        {
            Value = value;
            Location = context;
        }

        /// <summary>
        /// Position in the user query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Validated type, always Int32.
        /// </summary>
        public Type SemanticType { get { return typeof(int); } }

        /// <summary>
        /// Evaluation: Returns the value.
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
            var other = node as IntegerLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        /// <summary>
        /// Outputs a user-friendly string of this expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Validation: Nothing to do.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IntegerLiteralExpression Validate(IValidationScope context)
        {
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
