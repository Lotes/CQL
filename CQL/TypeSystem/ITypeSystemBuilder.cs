using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface ITypeSystemBuilder
    {
        IType<TType> AddType<TType>(string name, string usage, TypeDefaultFlags flags = TypeDefaultFlags.All);
        void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast);
        void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func);
        void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate);
        ITypeSystem Build();
    }
}
