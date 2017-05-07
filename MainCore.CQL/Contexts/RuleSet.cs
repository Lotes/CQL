using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.Metrics;
using MainCore.CQL.SyntaxTree;

namespace MainCore.CQL.Contexts
{
    public class RuleSet : IRuleSet
    {
        private Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, Tuple<Type, Func<object, object, object>>>>> binaryOpRules = new Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, Tuple<Type, Func<object, object, object>>>>>();
        private Dictionary<UnaryOperator, Dictionary<Type, Tuple<Type, Func<object, object>>>> unaryOpRules = new Dictionary<UnaryOperator, Dictionary<Type, Tuple<Type, Func<object, object>>>>();

        public void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate)
        {
            var left = typeof(TLeft);
            var right = typeof(TRight);
            var result = typeof(TResult);
            if (this[op, left, right] != null)
                throw new InvalidOperationException("Such a rule already exists!");
            binaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, Dictionary<Type, Tuple<Type, Func<object, object, object>>>>())
                .GetValueOrInsertedLazyDefault(left, () => new Dictionary<Type, Tuple<Type, Func<object, object, object>>>())
                [right] = new Tuple<Type, Func<object, object, object>>(result, (a,b) => aggregate((TLeft)a, (TRight)b));
        }

        public void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func)
        {
            var operand = typeof(TOperand);
            var result = typeof(TResult);
            if (this[op, operand] != null)
                throw new InvalidOperationException("Such a rule already exists!");
            unaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, Tuple<Type, Func<object, object>>>())
                [operand] = new Tuple<Type, Func<object, object>>(result, (a) => func((TOperand)a));
        }

        public Func<object, object, object> this[BinaryOperator op, Type left, Type right]
        {
            get
            {
                if (binaryOpRules.ContainsKey(op) && binaryOpRules[op].ContainsKey(left) && binaryOpRules[op][left].ContainsKey(right))
                    return binaryOpRules[op][left][right].Item2;
                return null;
            }
        }

        public Func<object, object> this[UnaryOperator op, Type operand]
        {
            get
            {
                if (unaryOpRules.ContainsKey(op) && unaryOpRules[op].ContainsKey(operand))
                    return unaryOpRules[op][operand].Item2;
                return null;
            }
        }

    }
}
