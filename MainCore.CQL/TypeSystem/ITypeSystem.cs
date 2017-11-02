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
        IEnumerable<QType> Types { get; }
        QType GetTypeByName(string name);
        IEnumerable<QType> GetTypesByPrefix(string prefix);
        // can throw exception
        QType GetTypeByNative(Type type);
        CoercionRule GetCoercionRule(Type original, Type casting);
        IEnumerable<CoercionRule> GetImplicitlyCastChain(Type original, Type destinationType);
        IEnumerable<Type> GetImplicitlyCastsTo(Type target);
        BinaryOperation GetBinaryOperation(BinaryOperator op, Type left, Type right);
        IEnumerable<BinaryOperation> GetBinaryOperations();
        UnaryOperation GetUnaryOperation(UnaryOperator op, Type operand);
        Type NullType { get; }
        Type EmptyType { get; }
    }
}
