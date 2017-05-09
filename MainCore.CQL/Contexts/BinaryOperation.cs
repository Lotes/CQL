
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public class BinaryOperation
    {
        public readonly Type LeftType;
        public readonly Type RightType;
        public readonly Type ResultType;
        public readonly BinaryOperator Operator;
        public readonly Func<object, object, object> Operation;

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
