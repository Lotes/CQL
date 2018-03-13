using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Represents an array index accessment.
    /// </summary>
    public class ArrayAccessExpression : IExpression<ArrayAccessExpression>
    {
        private IMemberIndexer indexer = null;

        /// <summary>
        /// Creates a AST node for array index accessing.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="primary"></param>
        /// <param name="indices"></param>
        public ArrayAccessExpression(IParserLocation location, IExpression primary, IEnumerable<IExpression> indices)
        {
            this.Location = location;
            this.ThisExpression = primary;
            Indices = indices;
        }

        /// <summary>
        /// All indices passed to the array accessment.
        /// </summary>
        public IEnumerable<IExpression> Indices { get; private set; }

        /// <summary>
        /// Position in the user query text of this AST node.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Type of the resulting value.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// THIS expression, which must be an array type after validation.
        /// </summary>
        public IExpression ThisExpression { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ArrayAccessExpression;
            if (other == null)
            {
                return false;
            }

            return this.Indices.StructurallyEquals(other.Indices);
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Validates THIS, which must have an indexer. If parameter count or type does 
        /// not match, throws a <see cref="LocateableException"/>.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ArrayAccessExpression Validate(IValidationScope context)
        {
            var thisExpression = ThisExpression.Validate(context);
            var indices = Indices.Select(i => i.Validate(context)).ToArray();
            var type = context.TypeSystem.GetTypeByNative(thisExpression.SemanticType);
            indexer = type.Indexer;
            if (indexer == null)
                throw new LocateableException(Location, "No indexer found!");
            SemanticType = indexer.ReturnType;
            var formalParameters = indexer.FormalParameters;
            if (formalParameters.Length != indices.Length)
                throw new LocateableException(Location, "Parameter count mismatch!");
            for(var index = 0; index<formalParameters.Length; index++)
            {
                var formal = formalParameters[index];
                var actual = indices[index].SemanticType;
                if(formal != actual)
                {
                    var chain = context.TypeSystem.GetImplicitlyCastChain(actual, formal);
                    indices[index] = chain.ApplyCast(indices[index], context, () => new LocateableException(indices[index].Location, "Parameter type mismatch!"));
                }
            }
            return this;
        }

        /// <summary>
        /// Evaluates the THIS expression and applies the evaluated indices as an array access.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            var @this = ThisExpression.Evaluate(context);
            var indices = Indices.Select(i => i.Evaluate(context)).ToArray();
            return indexer.Get(@this, indices);
        }
    }
}
