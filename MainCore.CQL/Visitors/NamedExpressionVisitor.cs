using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MainCore.CQL.Visitors
{
    public class NamedExpressionVisitor: CQLBaseVisitor<NamedExpression>
    {
        public readonly ExpressionVisitor ExpressionVisitor;

        public NamedExpressionVisitor(ExpressionVisitor expressionVisitor)
        {
            ExpressionVisitor = expressionVisitor;
        }

        public override NamedExpression VisitExprWithIdName([NotNull] CQLParser.ExprWithIdNameContext context)
        {
            var expression = ExpressionVisitor.Visit(context.expr);
            var name = context.name.Text;
            return new NamedExpression(context, expression, name);
        }

        public override NamedExpression VisitExprWithStringName([NotNull] CQLParser.ExprWithStringNameContext context)
        {
            var expression = ExpressionVisitor.Visit(context.expr);
            var name = context.name.Text;
            return new NamedExpression(context, expression, name);
        }

        public override NamedExpression VisitExprWithoutName([NotNull] CQLParser.ExprWithoutNameContext context)
        {
            var expression = ExpressionVisitor.Visit(context.expr);
            var name = (string)null;
            return new NamedExpression(context, expression, name);
        }
    }
}
