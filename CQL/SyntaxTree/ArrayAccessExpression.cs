using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class ArrayAccessExpression : IExpression<ArrayAccessExpression>
    {
        private IIndexer indexer = null;

        public ArrayAccessExpression(IParserLocation location, IExpression primary, IEnumerable<IExpression> indices)
        {
            this.Location = location;
            this.ThisExpression = primary;
            Indices = indices;
        }

        public IEnumerable<IExpression> Indices { get; private set; }
        public IParserLocation Location { get; private set; }
        public Type SemanticType { get; private set; }
        public IExpression ThisExpression { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ArrayAccessExpression;
            if (other == null)
                return false;
            return this.Indices.StructurallyEquals(other.Indices);
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public ArrayAccessExpression Validate(IScope<Type> context)
        {
            var thisExpression = ThisExpression.Validate(context);
            var indices = Indices.Select(i => i.Validate(context)).ToArray();
            var type = context.TypeSystem.GetTypeByNative(thisExpression.SemanticType);
            indexer = type.Indexer;
            if (indexer == null)
                throw new InvalidOperationException("No indexer found!");
            SemanticType = indexer.ReturnType;
            var formalParameters = indexer.FormalParameters;
            if (formalParameters.Length != indices.Length)
                throw new InvalidOperationException("Parameter count mismatch!");
            for(var index = 0; index<formalParameters.Length; index++)
            {
                var formal = formalParameters[index];
                var actualExpression = indices[index];
                if (!formal.IsAssignableFrom(actualExpression.SemanticType))
                    throw new InvalidOperationException("Parameter type mismatch!");
            }
            return this;
        }

        public object Evaluate(IScope<object> context)
        {
            var @this = ThisExpression.Evaluate(context);
            var indices = Indices.Select(i => i.Evaluate(context)).ToArray();
            return indexer.Get(@this, indices);
        }
    }
}
