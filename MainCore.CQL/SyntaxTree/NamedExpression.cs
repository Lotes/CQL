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
    public class NamedExpression: ISyntaxTreeNode<NamedExpression>
    {
        public IExpression Expression { get; private set; }
        public readonly string Name;

        public NamedExpression(ParserRuleContext context, IExpression expression, string name = null)
        {
            ParserContext = context;
            Expression = expression;
            Name = name;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as NamedExpression;
            if (other == null)
                return false;
            return this.Name == other.Name
                && this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            return Expression.ToString() + (string.IsNullOrEmpty(Name) ? "" : " AS \""+Name.Escape()+"\"");
        }

        public NamedExpression Validate(IContext context)
        {
            Expression = Expression.Validate(context);
            return this;
        }
    }
}
