using System;
using System.Collections.Generic;
using MainCore.Metrics;
using MainCore.CQL.SyntaxTree;

namespace MainCore.CQL.Contexts.Implementation
{
    public class RuleSet: IRuleSet
    {
        private Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, BinaryOperation>>> binaryOpRules = new Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, BinaryOperation>>>();
        private Dictionary<UnaryOperator, Dictionary<Type, UnaryOperation>> unaryOpRules = new Dictionary<UnaryOperator, Dictionary<Type, UnaryOperation>>();

        public void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate)
        {
            var left = typeof(TLeft);
            var right = typeof(TRight);
            var result = typeof(TResult);
            if (Get(op, left, right) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            binaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, Dictionary<Type, BinaryOperation>>())
                .GetValueOrInsertedLazyDefault(left, () => new Dictionary<Type, BinaryOperation>())
                [right] = new BinaryOperation(left, right, result, op, (a,b) => aggregate((TLeft)a, (TRight)b));
        }

        public void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func)
        {
            var operand = typeof(TOperand);
            var result = typeof(TResult);
            if (Get(op, operand) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            unaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, UnaryOperation>())
                [operand] = new UnaryOperation(operand, result, op, (a) => func((TOperand)a));
        }

        public BinaryOperation Get(BinaryOperator op, Type left, Type right)
        {
            if (binaryOpRules.ContainsKey(op) && binaryOpRules[op].ContainsKey(left) && binaryOpRules[op][left].ContainsKey(right))
                return binaryOpRules[op][left][right];
            return null;
        }

        public UnaryOperation Get(UnaryOperator op, Type operand)
        {
            if (unaryOpRules.ContainsKey(op) && unaryOpRules[op].ContainsKey(operand))
                return unaryOpRules[op][operand];
            return null;
        }
    }
}
