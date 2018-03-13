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
    /// AST node representing the EMPTY expression.
    /// </summary>
    public class EmptyExpression: IExpression<EmptyExpression>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public EmptyExpression(IParserLocation context) { Location = context; }
        /// <summary>
        /// Position of the expression in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }
        /// <summary>
        /// Validated type.
        /// </summary>
        public Type SemanticType { get; private set; }
        /// <summary>
        /// Evaluation...
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return new TypeSystem.Implementation.TypeSystem.Empty();
        }
        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as EmptyExpression != null;
        }
        /// <summary>
        /// Outputs a user-friendly representation as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "EMPTY";
        }

        /// <summary>
        /// Validation...
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public EmptyExpression Validate(IValidationScope context)
        {
            SemanticType = context.TypeSystem.EmptyType;
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }
    }
}
