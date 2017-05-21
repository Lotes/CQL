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
    public class NullExpression: IExpression<NullExpression>
    {
        public NullExpression(ParserRuleContext context) { ParserContext = context; }
        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get { return null; } }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as NullExpression != null;
        }

        public override string ToString()
        {
            return "NULL";
        }

        public NullExpression Validate(IContext context)
        {
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
