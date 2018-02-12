using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;

namespace CQL.SyntaxTree
{
    public class ArrayAccessExpression : IExpression<ArrayAccessExpression>
    {
        private MethodInfo getter;

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

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }

        public ArrayAccessExpression Validate(IContext context)
        {
            var thisExpression = ThisExpression.Validate(context);
            var indices = Indices.Select(i => i.Validate(context)).ToArray();
            var type = thisExpression.GetType();
            var property = type.GetProperty("Item", indices.Select(i => i.GetType()).ToArray());
            SemanticType = property.PropertyType;
            getter = property.GetMethod;
            return this;
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            var @this = ThisExpression.Evaluate(subject);
            var indices = Indices.Select(i => i.Evaluate(subject)).ToArray();
            return getter.Invoke(@this, indices);
        }
    }
}
