using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class TagExpression: IExpression
    {
        public readonly string CategoryName;
        public readonly string TagName;

        public TagExpression(ParserRuleContext context, string categoryName, string tagName)
        {
            CategoryName = categoryName;
            TagName = tagName;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{CategoryName}/{TagName}";
        }
    }
}
