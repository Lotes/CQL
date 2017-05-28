using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public interface ITypeSystemBuilder
    {
        void AddType<TType>(string name);
        void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast);
        void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        //void AddInRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        //void AddIsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func);
        void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate);
        ITypeSystem Build();
    }
}
