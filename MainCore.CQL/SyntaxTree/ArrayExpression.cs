using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class ArrayExpression: IExpression<ArrayExpression>
    {
        public IEnumerable<IExpression> Elements { get; private set; }

        public ArrayExpression(ParserRuleContext context, IEnumerable<IExpression> elements)
        {
            Elements = elements.ToArray();
            ParserContext = context;
            SemanticType = null;
        }

        public ParserRuleContext ParserContext { get; private set; }

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
            Elements = Elements.Select(e => e.Validate(context)).ToArray();
            SemanticType = Elements.Select(e => e.SemanticType).GetCommonBaseClass();
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
