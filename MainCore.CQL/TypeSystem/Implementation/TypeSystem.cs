using MainCore.CQL.SyntaxTree;
using QuickGraph;
using QuickGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem.Implementation
{
    public class TypeSystem: ITypeSystem
    {
        private Dictionary<string, QType> types = new Dictionary<string, QType>();
        private Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, BinaryOperation>>> binaryOpRules = new Dictionary<BinaryOperator, Dictionary<Type, Dictionary<Type, BinaryOperation>>>();
        private Dictionary<UnaryOperator, Dictionary<Type, UnaryOperation>> unaryOpRules = new Dictionary<UnaryOperator, Dictionary<Type, UnaryOperation>>();
        private BidirectionalGraph<Type, TaggedEdge<Type, CoercionRule>> allCoercionRules = new BidirectionalGraph<Type, TaggedEdge<Type, CoercionRule>>();
        private BidirectionalGraph<Type, TaggedEdge<Type, CoercionRule>> implicitCoercionRules = new BidirectionalGraph<Type, TaggedEdge<Type, CoercionRule>>();

        public void AddType<TType>(string name)
        {
            if (types.Values.Any(t => t.ActualType == typeof(TType)))
                throw new InvalidOperationException("Type is already registered!");
            types.Add(name.ToLower(), new QType(name, typeof(TType)));
        }

        public void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast)
        {
            var original = typeof(TOriginalType);
            var casting = typeof(TCastingType);
            var rule = new CoercionRule(kind, original, casting, a => cast((TOriginalType)a));
            TaggedEdge<Type, CoercionRule> existingEdge;
            if (allCoercionRules.TryGetEdge(original, casting, out existingEdge))
                throw new InvalidOperationException("Such a rule does already exist!");
            var edge = new TaggedEdge<Type, CoercionRule>(original, casting, rule);
            if(kind == CoercionKind.Implicit)
            {
                implicitCoercionRules.AddVertex(original);
                implicitCoercionRules.AddVertex(casting);
                implicitCoercionRules.AddEdge(edge);
                IDictionary<Type, int> components;
                if(implicitCoercionRules.StronglyConnectedComponents(out components) != implicitCoercionRules.Vertices.Count())
                {
                    implicitCoercionRules.RemoveEdge(edge);
                    throw new InvalidOperationException("This action would create an implicit conversion cycle!");
                }
            }
            allCoercionRules.AddVertex(original);
            allCoercionRules.AddVertex(casting);
            allCoercionRules.AddEdge(edge);
        }

        public void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate)
        {
            var left = typeof(TLeft);
            var right = typeof(TRight);
            var result = typeof(TResult);
            if (GetBinaryOperation(op, left, right) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            binaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, Dictionary<Type, BinaryOperation>>())
                .GetValueOrInsertedLazyDefault(left, () => new Dictionary<Type, BinaryOperation>())
                [right] = new BinaryOperation(left, right, result, op, (a, b) => aggregate((TLeft)a, (TRight)b));
        }

        public void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func)
        {
            var operand = typeof(TOperand);
            var result = typeof(TResult);
            if (GetUnaryOperation(op, operand) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            unaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<Type, UnaryOperation>())
                [operand] = new UnaryOperation(operand, result, op, (a) => func((TOperand)a));
        }

        public BinaryOperation GetBinaryOperation(BinaryOperator op, Type left, Type right)
        {
            if (binaryOpRules.ContainsKey(op) && binaryOpRules[op].ContainsKey(left) && binaryOpRules[op][left].ContainsKey(right))
                return binaryOpRules[op][left][right];
            return null;
        }

        public UnaryOperation GetUnaryOperation(UnaryOperator op, Type operand)
        {
            if (unaryOpRules.ContainsKey(op) && unaryOpRules[op].ContainsKey(operand))
                return unaryOpRules[op][operand];
            return null;
        }

        public IEnumerable<QType> Types { get { return types.Values; } }

        IEnumerable<QType> ITypeSystem.Types
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CoercionRule GetCoercionRule(Type original, Type casting)
        {
            TaggedEdge<Type, CoercionRule> edge;
            if (allCoercionRules.TryGetEdge(original, casting, out edge))
                return edge.Tag;
            return null;
        }

        public QType GetType(string name)
        {
            QType type;
            if (types.TryGetValue(name.ToLower(), out type))
                return type;
            return null;
        }
    }
}
