using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public class UnaryOperation
    {
        public readonly Type OperandType;
        public readonly Type ResultType;
        public readonly UnaryOperator Operator;
        public readonly Func<object, object> Operation;
        public UnaryOperation(Type operandType, Type resultType, UnaryOperator @operator, Func<object, object> operation)
        {
            OperandType = operandType;
            ResultType = resultType;
            Operator = @operator;
            Operation = operation;
        }
    }
}
