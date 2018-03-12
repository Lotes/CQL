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
    /// An expression that addresses a variable from the EvaluationScope.
    /// </summary>
    /// <seealso cref="CQL.SyntaxTree.IExpression{CQL.SyntaxTree.VariableExpression}" />
    /// <seealso cref="CQL.Contexts.Implementation.EvaluationScope" />
    public class VariableExpression : IExpression<VariableExpression>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableExpression"/> class.
        /// </summary>
        /// <param name="location">The location when parsed from a user query.</param>
        /// <param name="identifier">The identifier addressing the variable in the evaluation scope.</param>
        public VariableExpression(IParserLocation location, string identifier)
        {
            this.Location = location;
            this.Identifier = identifier;
            this.SemanticType = null;
        }

        /// <summary>
        /// The variable identifier of this expresssion.
        /// </summary>
        public string Identifier { get; private set; }
        /// <summary>
        /// The location of this expression, when parsed from a user query.
        /// </summary>
        public IParserLocation Location { get; private set; }
        /// <summary>
        /// The semantic type of this variable expression, after it was parsed and validated.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Outputs a user-readable representation of this variable expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Identifier;
        }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as VariableExpression;
            if (other == null)
            {
                return false;
            }

            return other.Identifier == this.Identifier;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Validation of expression: checks whether the variable is known and returns its type.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="LocateableException">Unknown field!</exception>
        public VariableExpression Validate(IScope<Type> context)
        {
            if (!context.TryGetVariable(Identifier, out IVariable<Type> nameable))
            {
                throw new LocateableException(Location, "Unknown field!");
            }

            SemanticType = nameable.Value;
            return this;
        }

        /// <summary>
        /// Evaluation of expression: reads the value of the variable from the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="LocateableException">Unknown field!</exception>
        public object Evaluate(IScope<object> context)
        {
            if (!context.TryGetVariable(Identifier, out IVariable<object> nameable))
            {
                throw new LocateableException(Location, "Unknown field!");
            }

            return nameable.Value;
        }
    }
}
