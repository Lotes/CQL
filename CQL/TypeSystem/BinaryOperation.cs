
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Binary operation rule.
    /// </summary>
    public class BinaryOperation
    {
        /// <summary>
        /// Type of the left operand.
        /// </summary>
        public readonly Type LeftType;
        /// <summary>
        /// Type of the right operand.
        /// </summary>
        public readonly Type RightType;
        /// <summary>
        /// Type of the result.
        /// </summary>
        public readonly Type ResultType;
        /// <summary>
        /// Used operator.
        /// </summary>
        public readonly BinaryOperator Operator;
        /// <summary>
        /// Actual operation as lambda function.
        /// </summary>
        public readonly Func<object, object, object> Operation;

        /// <summary>
        /// Creates a binary operation.
        /// </summary>
        /// <param name="leftType"></param>
        /// <param name="rightType"></param>
        /// <param name="resultType"></param>
        /// <param name="operator"></param>
        /// <param name="operation"></param>
        public BinaryOperation(Type leftType, Type rightType, Type resultType, BinaryOperator @operator, Func<object, object, object> operation)
        {
            LeftType = leftType;
            RightType = rightType;
            ResultType = resultType;
            Operator = @operator;
            Operation = operation;
        }
    }
}
