using CQL.SyntaxTree;
using QuickGraph;
using QuickGraph.Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// The default implementation of <see cref="ITypeSystem"/>
    /// </summary>
    public class TypeSystem: ITypeSystem
    {
        /// <summary>
        /// Default NULL class
        /// </summary>
        public class Null { }
        /// <summary>
        /// Default EMPTY class
        /// </summary>
        public class Empty { }

        private Dictionary<string, IType> types = new Dictionary<string, IType>();
        private Dictionary<BinaryOperator, Dictionary<System.Type, Dictionary<System.Type, BinaryOperation>>> binaryOpRules = new Dictionary<BinaryOperator, Dictionary<System.Type, Dictionary<System.Type, BinaryOperation>>>();
        private Dictionary<UnaryOperator, Dictionary<System.Type, UnaryOperation>> unaryOpRules = new Dictionary<UnaryOperator, Dictionary<System.Type, UnaryOperation>>();
        private BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>> allCoercionRules = new BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>>();
        private BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>> implicitCoercionRules = new BidirectionalGraph<System.Type, TaggedEdge<System.Type, CoercionRule>>();

        /// <summary>
        /// Adds a new native type.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="name"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public IType<TType> AddType<TType>(string name, string usage)
        {
            if (types.Values.Any(t => t.NativeType == typeof(TType)))
                throw new InvalidOperationException("Type is already registered!");
            Debug.WriteLine($"- added type '{name}'");
            IType<TType> result;
            types.Add(name.ToLower(), result = new Type<TType>(name, usage));
            return result;
        }

        /// <summary>
        /// Adds a new coercion rule. Trys to avoid cyclic implicit casts chains.
        /// </summary>
        /// <typeparam name="TOriginalType"></typeparam>
        /// <typeparam name="TCastingType"></typeparam>
        /// <param name="kind"></param>
        /// <param name="cast"></param>
        public void AddCoercionRule<TOriginalType, TCastingType>(CoercionKind kind, Func<TOriginalType, TCastingType> cast)
        {
            var original = typeof(TOriginalType);
            var casting = typeof(TCastingType);
            if (GetTypeByNative(original) == null) throw new UnknownTypeException(original);
            if (GetTypeByNative(casting) == null) throw new UnknownTypeException(casting);
            var rule = new CoercionRule(kind, original, casting, a => cast((TOriginalType)a));
            if (allCoercionRules.TryGetEdge(original, casting, out TaggedEdge<Type, CoercionRule> existingEdge))
                throw new InvalidOperationException("Such a rule does already exist!");
            var edge = new TaggedEdge<System.Type, CoercionRule>(original, casting, rule);
            if(kind == CoercionKind.Implicit)
            {
                implicitCoercionRules.AddVertex(original);
                implicitCoercionRules.AddVertex(casting);
                implicitCoercionRules.AddEdge(edge);
                if (implicitCoercionRules.StronglyConnectedComponents(out IDictionary<Type, int> components) != implicitCoercionRules.Vertices.Count())
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

        /// <summary>
        /// Adds binary rules.
        /// </summary>
        /// <typeparam name="TLeft"></typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="aggregate"></param>
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

        /// <summary>
        /// Adds unary rules.
        /// </summary>
        /// <typeparam name="TOperand"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="op"></param>
        /// <param name="func"></param>
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

        /// <summary>
        /// Lookup for binary operations.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public BinaryOperation GetBinaryOperation(BinaryOperator op, System.Type left, System.Type right)
        {
            if (binaryOpRules.ContainsKey(op) && binaryOpRules[op].ContainsKey(left) && binaryOpRules[op][left].ContainsKey(right))
                return binaryOpRules[op][left][right];
            return null;
        }

        /// <summary>
        /// Lookup for unary operations.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public UnaryOperation GetUnaryOperation(UnaryOperator op, System.Type operand)
        {
            if (unaryOpRules.ContainsKey(op) && unaryOpRules[op].ContainsKey(operand))
                return unaryOpRules[op][operand];
            return null;
        }

        /// <summary>
        /// Returns all registered types.
        /// </summary>
        public IEnumerable<IType> Types { get { return types.Values; } }

        /// <summary>
        /// Returns the null type.
        /// </summary>
        public System.Type NullType { get { return typeof(Null); } }
        /// <summary>
        /// Returns the empty type.
        /// </summary>
        public System.Type EmptyType { get { return typeof(Empty); } }
         
        /// <summary>
        /// Returns a coercion rule if given, null otherwise.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="casting"></param>
        /// <returns></returns>
        public CoercionRule GetCoercionRule(System.Type original, System.Type casting)
        {
            if (allCoercionRules.TryGetEdge(original, casting, out TaggedEdge<Type, CoercionRule> edge))
                return edge.Tag;
            return null;
        }

        /// <summary>
        /// get a registered type by its name (case insensitive)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IType GetTypeByName(string name)
        {
            if (types.TryGetValue(name.ToLower(), out IType type))
                return type;
            return null;
        }

        /// <summary>
        /// Get all types matching a prefix (case insensitve).
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public IEnumerable<IType> GetTypesByPrefix(string prefix)
        {
            prefix = prefix.ToLower();
            return types.Where(kv => kv.Key.StartsWith(prefix)).Select(kv => kv.Value).ToArray();
        }

        /// <summary>
        /// Returns a possible implicit cast chain.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public IEnumerable<CoercionRule> GetImplicitlyCastChain(System.Type original, System.Type destinationType)
        {
            if (implicitCoercionRules.ContainsVertex(original) && implicitCoercionRules.ShortestPathsDijkstra(t => 1, original)(destinationType, out IEnumerable<TaggedEdge<Type, CoercionRule>> result))
                return result.Select(e => e.Tag).ToArray();
            return Enumerable.Empty<CoercionRule>();
        }

        /// <summary>
        /// Get a type by its native representation.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IType GetTypeByNative(System.Type type)
        {
            var matchingQTypes = types.Values.Where(q => q.NativeType.IsAssignableFrom(type)).ToArray();
            if (matchingQTypes.Length == 0)
                return null;
            if (matchingQTypes.Length == 1)
                return matchingQTypes[0];
            throw new AmbigiousTypeException(type, matchingQTypes);
        }

        /// <summary>
        /// Returns all registered binary operations.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BinaryOperation> GetBinaryOperations()
        {
            return binaryOpRules.Values.SelectMany(a => a.Values.SelectMany(b => b.Values));
        }

        /// <summary>
        /// Gets all source types for a given target type, that can be gained by implicit cast.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IEnumerable<System.Type> GetImplicitlyCastsTo(System.Type target)
        {
            if (implicitCoercionRules.TryGetInEdges(target, out IEnumerable<TaggedEdge<Type, CoercionRule>> edges))
                return edges.Select(e => e.Source).Distinct();
            return Enumerable.Empty<System.Type>();
        }

        /// <summary>
        /// Returns a registered type by its native representation.
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public IType<TType> GetTypeByNative<TType>()
        {
            return (IType<TType>)GetTypeByNative(typeof(TType));
        }
    }
}
