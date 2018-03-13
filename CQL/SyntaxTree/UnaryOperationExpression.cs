using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// AST node, representing a unary operation.
    /// </summary>
    public class UnaryOperationExpression: IExpression<UnaryOperationExpression>
    {
        /// <summary>
        /// The expression on whcih the unary operator will be applied.
        /// </summary>
        public IExpression Expression { get; private set; }
        /// <summary>
        /// The applied operator.
        /// </summary>
        public readonly UnaryOperator Operator;
        /// <summary>
        /// The operation behind the operator. Will be set during validation.
        /// </summary>
        private UnaryOperation operation;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="operator"></param>
        /// <param name="expression"></param>
        public UnaryOperationExpression(IParserLocation context, UnaryOperator @operator, IExpression expression)
        {
            Expression = expression;
            Operator = @operator;
            Location = context;
        }

        /// <summary>
        /// Location in the query text of this AST node.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// The validated type of this expression.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as UnaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.Expression.StructurallyEquals(other.Expression);
        }

        /// <summary>
        /// Outputs a user-friendly string representation of this expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string opStr;
            switch(Operator)
            {
                case UnaryOperator.Minus: opStr = "-"; break;
                case UnaryOperator.Plus: opStr = "+"; break;
                case UnaryOperator.Not: opStr = "NOT"; break;
                default: throw new InvalidOperationException($"Unhandled operator: {Operator}");
            }
            return $"{opStr} {Expression.ToString()}";
        }

        /// <summary>
        /// Validation: Determine the actual operation and return type of this unary operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public UnaryOperationExpression Validate(IValidationScope context)
        {
            Expression = Expression.Validate(context);
            operation = context.TypeSystem.GetUnaryOperation(Operator, Expression.SemanticType);
            if (operation == null)
            {
                throw new LocateableException(Location, "Unary operation not supported for that type of operand!");
            }
            SemanticType = operation.ResultType;
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Evaluation: execute the unary operation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            return operation.Operation(Expression.Evaluate(context));
        }
    }
}
