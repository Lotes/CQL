using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public interface ITypeSystemBuilder
    {
        void AddType<TType>();
        void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast);
        void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        ITypeSystem Build();
    }
}
