using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// A typesystem a a set of types and rules (operations, relations) between these types.
    /// </summary>
    public interface ITypeSystem
    {
        /// <summary>
        /// Returns all registered types.
        /// </summary>
        IEnumerable<IType> Types { get; }
        /// <summary>
        /// Returns null or a type by its name which was used to register it (case insensitive).
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IType GetTypeByName(string name);
        /// <summary>
        /// Returns a set of types that start with the given prefix (case insensitive).
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        IEnumerable<IType> GetTypesByPrefix(string prefix);
        /// <summary>
        /// Returns a registered type when passing the native type. Return null, if it can not be found.
        /// Throws an <see cref="AmbigiousTypeException"/> when more than one type is possible.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IType GetTypeByNative(Type type);
        /// <summary>
        /// <see cref="GetTypeByNative(Type)"/>
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        IType<TType> GetTypeByNative<TType>();
        /// <summary>
        /// Returns a coercion rule between two type, if it exists. NULL otherwise.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="casting"></param>
        /// <returns></returns>
        CoercionRule GetCoercionRule(Type original, Type casting);
        /// <summary>
        /// Returns a chain of implicit casts for converting a variable of an original type into a destination type.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        IEnumerable<CoercionRule> GetImplicitlyCastChain(Type original, Type destinationType);
        /// <summary>
        /// Returns all possible implicit casts from a given type.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        IEnumerable<Type> GetImplicitlyCastsTo(Type target);
        /// <summary>
        /// Returns a binary operation between two types if it exists. NULL otherwise.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        BinaryOperation GetBinaryOperation(BinaryOperator op, Type left, Type right);
        /// <summary>
        /// Returns all binary operations registered.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BinaryOperation> GetBinaryOperations();
        /// <summary>
        /// Returns all unary operations registered.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        UnaryOperation GetUnaryOperation(UnaryOperator op, Type operand);
        /// <summary>
        /// The null type.
        /// </summary>
        Type NullType { get; }
        /// <summary>
        /// The empty type.
        /// </summary>
        Type EmptyType { get; }
    }
}
