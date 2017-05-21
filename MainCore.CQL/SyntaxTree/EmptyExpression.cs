using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class EmptyExpression: IExpression<EmptyExpression>
    {
        public EmptyExpression(ParserRuleContext context) { ParserContext = context; }
        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get { return null; } }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as EmptyExpression != null;
        }

        public override string ToString()
        {
            return "EMPTY";
        }

        public EmptyExpression Validate(IContext context)
        {
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
