using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem.Implementation
{
    public class TypeSystemBuilder: ITypeSystemBuilder
    {
        private TypeSystem typeSystem = new TypeSystem();

        public void AddType<TType>(string name)
        {
            typeSystem.AddType<TType>(name);
            AddEqualsRule<TType>((a, b) => a.Equals(b));
            if (typeof(TType).IsAssignableFrom(typeof(IComparable)))
                AddLessRule<TType>((a, b) => ((IComparable)a).CompareTo(b) < 0);
        }

        public void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast)
        {
            typeSystem.AddCoercionRule(kind, cast);
        }

        public void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.Contains, aggregate);
            typeSystem.AddRule<TLeft, TRight, bool>(BinaryOperator.DoesNotContain, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        public void AddEqualsRule<TOperand>(Func<TOperand, TOperand, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.Equals, aggregate);
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.NotEquals, (lhs, rhs) => !aggregate(lhs, rhs));
        }

        public void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate)
        {
            typeSystem.AddRule(BinaryOperator.LessThan, aggregate);
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThan, (lhs, rhs) => aggregate(rhs, lhs));
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.GreaterThanEquals, (lhs, rhs) => !aggregate(lhs, rhs));
            typeSystem.AddRule<TOperand, TOperand, bool>(BinaryOperator.LessThanEquals, (lhs, rhs) => !aggregate(rhs, lhs));
        }

        public ITypeSystem Build()
        {
            return typeSystem;
        }
    }
}
