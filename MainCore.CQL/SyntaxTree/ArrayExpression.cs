using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace MainCore.CQL.SyntaxTree
{
    public class ArrayExpression: IExpression
    {
        public readonly IEnumerable<IExpression> Elements;

        public ArrayExpression(ParserRuleContext context, IEnumerable<IExpression> elements)
        {
            Elements = elements;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

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
    }
}
