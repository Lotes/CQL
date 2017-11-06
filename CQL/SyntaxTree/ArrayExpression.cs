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

        public ArrayExpression(ParserRuleContext context, IEnumerable<IExpression> elements)
        {
            Elements = elements.ToArray();
            ParserContext = context;
            SemanticType = null;
            ElementType = null;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type ElementType { get; private set; }
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

        public ArrayExpression Validate(IContext context)
        {
            var elements = Elements.Select(e => e.Validate(context)).ToArray();
            //Attention! The array has at least one element.
            ElementType = Elements.First().SemanticType;
            for(var index=1; index<elements.Length; index++)
                if(elements[index].SemanticType != ElementType)
                    ElementType = context.AlignTypes(ref elements[index-1], ref elements[index], () => new LocateableException(ParserContext, "Could not unify type of this array!"));
            Elements = elements;
            ElementType = Elements.Select(e => e.SemanticType).GetCommonBaseClass();
            SemanticType = ElementType.MakeArrayType();
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return Elements.Select(elem => elem.Evaluate(subject)).ToArray();
        }
    }
}
