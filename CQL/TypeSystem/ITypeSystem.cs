using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface ITypeSystem
    {
        IEnumerable<IType> Types { get; }
        IType GetTypeByName(string name);
        IEnumerable<IType> GetTypesByPrefix(string prefix);
        // can throw exception
        IType GetTypeByNative(Type type);
        IType<TType> GetTypeByNative<TType>();
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
