using CQL.SyntaxTree;
using QuickGraph;
using QuickGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CQL.TypeSystem.Implementation
{
    public class TypeSystem: ITypeSystem
    {
        public class Null { }
        public class Empty { }

        private Dictionary<string, IType> types = new Dictionary<string, IType>();
        private Dictionary<BinaryOperator, Dictionary<System.Type, Dictionary<System.Type, BinaryOperation>>> binaryOpRules = new Dictionary<BinaryOperator, Dictionary<System.Type, Dictionary<System.Type, BinaryOperation>>>();
        private Dictionary<UnaryOperator, Dictionary<System.Type, UnaryOperation>> unaryOpRules = new Dictionary<UnaryOperator, Dictionary<System.Type, UnaryOperation>>();
        private BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>> allCoercionRules = new BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>>();
        private BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>> implicitCoercionRules = new BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>>();

        public IType<TType> AddType<TType>(string name, string usage)
        {
            if (types.Values.Any(t => t.CSharpType == typeof(TType)))
                throw new InvalidOperationException("Type is already registered!");
            Debug.WriteLine($"- added type '{name}'");
            IType<TType> result;
            types.Add(name.ToLower(), result = new Type<TType>(name, usage));
            return result;
        }

        public void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast)
        {
            var original = typeof(TOriginalType);
            var casting = typeof(TCastingType);
            if (GetTypeByNative(original) == null) throw new UnknownTypeException(original);
            if (GetTypeByNative(casting) == null) throw new UnknownTypeException(casting);
            var rule = new CoercionRule(kind, original, casting, a => cast((TOriginalType)a));
            TaggedEdge<System.Type, CoercionRule> existingEdge;
            if (allCoercionRules.TryGetEdge(original, casting, out existingEdge))
                throw new InvalidOperationException("Such a rule does already exist!");
            var edge = new TaggedEdge<System.Type, CoercionRule>(original, casting, rule);
            if(kind == CoercionKind.Implicit)
            {
                implicitCoercionRules.AddVertex(original);
                implicitCoercionRules.AddVertex(casting);
                implicitCoercionRules.AddEdge(edge);
                IDictionary<System.Type, int> components;
                if(implicitCoercionRules.StronglyConnectedComponents(out components) != implicitCoercionRules.Vertices.Count())
                {
                    implicitCoercionRules.RemoveEdge(edge);
                    throw new InvalidOperationException("This action would create an implicit conversion cycle!");
                }
            }
            allCoercionRules.AddVertex(original);
            allCoercionRules.AddVertex(casting);
            allCoercionRules.AddEdge(edge);
            Debug.WriteLine($"- added coercion rule from '{original.Name}' to '{casting.Name}'");
        }

        public void AddRule<TLeft, TRight, TResult>(BinaryOperator op, Func<TLeft, TRight, TResult> aggregate)
        {
            var left = typeof(TLeft);
            var right = typeof(TRight);
            var result = typeof(TResult);
            if (GetTypeByNative(left) == null) throw new UnknownTypeException(left);
            if (GetTypeByNative(right) == null) throw new UnknownTypeException(right);
            if (GetTypeByNative(result) == null) throw new UnknownTypeException(result);
            if (GetBinaryOperation(op, left, right) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            binaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<System.Type, Dictionary<System.Type, BinaryOperation>>())
                .GetValueOrInsertedLazyDefault(left, () => new Dictionary<System.Type, BinaryOperation>())
                [right] = new BinaryOperation(left, right, result, op, (a, b) => aggregate((TLeft)a, (TRight)b));
            Debug.WriteLine($"- added binary operation '{op}: {left.Name} x {right.Name} -> {result.Name}'");
        }

        public void AddRule<TOperand, TResult>(UnaryOperator op, Func<TOperand, TResult> func)
        {
            var operand = typeof(TOperand);
            var result = typeof(TResult);
            if (GetTypeByNative(operand) == null) throw new UnknownTypeException(operand);
            if (GetTypeByNative(result) == null) throw new UnknownTypeException(result);
            if (GetUnaryOperation(op, operand) != null)
                throw new InvalidOperationException("Such a rule already exists!");
            unaryOpRules.GetValueOrInsertedLazyDefault(op, () => new Dictionary<System.Type, UnaryOperation>())
                [operand] = new UnaryOperation(operand, result, op, (a) => func((TOperand)a));
            Debug.WriteLine($"- added unary operation '{op}: {operand.Name} -> {result.Name}'");
        }

        public BinaryOperation GetBinaryOperation(BinaryOperator op, System.Type left, System.Type right)
        {
            if (binaryOpRules.ContainsKey(op) && binaryOpRules[op].ContainsKey(left) && binaryOpRules[op][left].ContainsKey(right))
                return binaryOpRules[op][left][right];
            return null;
        }

        public UnaryOperation GetUnaryOperation(UnaryOperator op, System.Type operand)
        {
            if (unaryOpRules.ContainsKey(op) && unaryOpRules[op].ContainsKey(operand))
                return unaryOpRules[op][operand];
            return null;
        }

        public IEnumerable<IType> Types { get { return types.Values; } }

        public System.Type NullType { get { return typeof(Null); } }
        public System.Type EmptyType { get { return typeof(Empty); } }
         

        public CoercionRule GetCoercionRule(System.Type original, System.Type casting)
        {
            TaggedEdge<System.Type, CoercionRule> edge;
            if (allCoercionRules.TryGetEdge(original, casting, out edge))
                return edge.Tag;
            return null;
        }

        public IType GetTypeByName(string name)
        {
            IType type;
            if (types.TryGetValue(name.ToLower(), out type))
                return type;
            return null;
        }

        public IEnumerable<IType> GetTypesByPrefix(string prefix)
        {
            prefix = prefix.ToLower();
            return types.Where(kv => kv.Key.StartsWith(prefix)).Select(kv => kv.Value).ToArray();
        }

        public IEnumerable<CoercionRule> GetImplicitlyCastChain(System.Type original, System.Type destinationType)
        {
            IEnumerable<TaggedEdge<System.Type, CoercionRule>> result;
            if (implicitCoercionRules.ContainsVertex(original) && implicitCoercionRules.ShortestPathsDijkstra(t => 1, original)(destinationType, out result))
                return result.Select(e => e.Tag).ToArray();
            return Enumerable.Empty<CoercionRule>();
        }

        public IType GetTypeByNative(System.Type type)
        {
            var matchingQTypes = types.Values.Where(q => q.CSharpType.IsAssignableFrom(type)).ToArray();
            if (matchingQTypes.Length == 0)
                return null;
            if (matchingQTypes.Length == 1)
                return matchingQTypes[0];
            throw new AmbigiousTypeException(type, matchingQTypes);
        }

        public IEnumerable<BinaryOperation> GetBinaryOperations()
        {
            return binaryOpRules.Values.SelectMany(a => a.Values.SelectMany(b => b.Values));
        }

        public IEnumerable<System.Type> GetImplicitlyCastsTo(System.Type target)
        {
            IEnumerable<TaggedEdge<System.Type, CoercionRule>> edges = null;
            if (implicitCoercionRules.TryGetInEdges(target, out edges))
                return edges.Select(e => e.Source).Distinct();
            return Enumerable.Empty<System.Type>();
        }

        public IType<TType> GetTypeByNative<TType>()
        {
            return (IType<TType>)GetTypeByNative(typeof(TType));
        }
    }
}
