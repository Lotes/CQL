using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class ArrayExpression: IExpression<ArrayExpression>
    {
        public IEnumerable<IExpression> Elements { get; private set; }

        public ArrayExpression(IParserLocation context, IEnumerable<IExpression> elements)
        {
            Elements = elements.ToArray();
            Location = context;
            SemanticType = null;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ArrayExpression;
            if (other == null)
                return false;
            return this.Elements.StructurallyEquals(other.Elements);
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Elements.Select(e => e.ToString()))}]";
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public ArrayExpression Validate(IScope<Type> context)
        {
            var elements = Elements.Select(e => e.Validate(context)).ToArray();
            //Attention! The array has at least one element.
            var elementType = Elements.First().SemanticType;
            for(var index=1; index<elements.Length; index++)
                if(elements[index].SemanticType != elementType)
                    elementType = context.AlignTypes(ref elements[index-1], ref elements[index], () => new LocateableException(Location, "Could not unify type of this array!"));
            Elements = elements;
            elementType = Elements.Select(e => e.SemanticType).GetCommonBaseClass();
            SemanticType = elementType.MakeArrayType();
            return this;
        }

        public object Evaluate(IScope<object> context)
        {
            var values = Elements.Select(elem => elem.Evaluate(context)).ToArray();
            var result = (Array)Activator.CreateInstance(SemanticType, values.Length);
            for (var index = 0; index < values.Length; index++)
                result.SetValue(values[index], index);
            return result;
        }
    }
}
