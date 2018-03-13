using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Represents a unary operation.
    /// </summary>
    public class UnaryOperation
    {
        /// <summary>
        /// Type of the operand.
        /// </summary>
        public readonly Type OperandType;
        /// <summary>
        /// Return type of the operation.
        /// </summary>
        public readonly Type ResultType;
        /// <summary>
        /// The applied operator.
        /// </summary>
        public readonly UnaryOperator Operator;
        /// <summary>
        /// Operation delegate which has to be applied to the input operand.
        /// </summary>
        public readonly Func<object, object> Operation;
        /// <summary>
        /// Creates an unary operation info object.
        /// </summary>
        /// <param name="operandType"></param>
        /// <param name="resultType"></param>
        /// <param name="operator"></param>
        /// <param name="operation"></param>
        public UnaryOperation(Type operandType, Type resultType, UnaryOperator @operator, Func<object, object> operation)
        {
            OperandType = operandType;
            ResultType = resultType;
            Operator = @operator;
            Operation = operation;
        }
    }
}
