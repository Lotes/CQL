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
    /// AST node representing the NULL literal.
    /// </summary>
    public class NullExpression: IExpression<NullExpression>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public NullExpression(IParserLocation context) { Location = context; }
        /// <summary>
        /// Position in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }
        /// <summary>
        /// Validated type.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Evaluation. Nothing to do.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return null;
        }

        /// <summary>
        /// Deep equals
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as NullExpression != null;
        }

        /// <summary>
        /// User-friendly representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "NULL";
        }

        /// <summary>
        /// Validation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public NullExpression Validate(IValidationScope context)
        {
            SemanticType = context.TypeSystem.NullType;
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
