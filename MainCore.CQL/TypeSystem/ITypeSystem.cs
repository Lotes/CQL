using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public interface ITypeSystem
    {
        IEnumerable<Type> Types { get; }
        CoercionRule GetCoercionRule(Type original, Type casting);
        BinaryOperation GetBinaryOperation(BinaryOperator op, Type left, Type right);
        UnaryOperation GetUnaryOperation(UnaryOperator op, Type operand);
    }
}
