using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Helper for building type systems.
    /// </summary>
    public interface ITypeSystemBuilder
    {
        /// <summary>
        /// Adds a new type known in CQL under the given name. See <see cref="TypeDefaultFlags"/> for default initialization.
        /// </summary>
        /// <typeparam name="TType">the new introduced type</typeparam>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        IType<TType> AddType<TType>(string name, string usage, TypeDefaultFlags flags = TypeDefaultFlags.All);
        /// <summary>
        /// Add a casting rule, implicit or explicit. Implicit rules will be applied during validation process if needed.
        /// </summary>
        /// <typeparam name="TOriginalType"></typeparam>
        /// <typeparam name="TCastingType"></typeparam>
        /// <param name="kind"></param>
        /// <param name="cast"></param>
        void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast);
        /// <summary>
        /// Adds a containment rule "left contains right".
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <param name="aggregate"></param>
        void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        /// <summary>
        /// Adds an equality relation for a given type.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <param name="aggregate"></param>
        void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        /// <summary>
        /// The less rule is sufficient to realize all comparsion operations (greater, greater equals, less and less equals).
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <param name="aggregate"></param>
        void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        /// <summary>
        /// Low level function to add any unary operation.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="func"></param>
        void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func);
        /// <summary>
        /// Low level function to add any binary operation.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="aggregate"></param>
        void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate);
        /// <summary>
        /// Takes all added rules and creates a type system from these.
        /// </summary>
        /// <returns></returns>
        ITypeSystem Build();
    }
}
