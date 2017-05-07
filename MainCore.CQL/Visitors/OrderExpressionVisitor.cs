using Antlr4.Runtime.Misc;
using MainCore.CQL.SyntaxTree;

namespace MainCore.CQL.Visitors
{
    public class OrderExpressionVisitor: CQLBaseVisitor<OrderExpression>
    {
        private ExpressionVisitor expressionVisitor;

        public OrderExpressionVisitor(ExpressionVisitor expressionVisitor)
        {
            this.expressionVisitor = expressionVisitor;
        }

        public override OrderExpression VisitOrderByDesc([NotNull] CQLParser.OrderByDescContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            return new OrderExpression(SortOrder.Descending, expression);
        }

        public override OrderExpression VisitOrderByAsc([NotNull] CQLParser.OrderByAscContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            return new OrderExpression(SortOrder.Ascending, expression);
        }

        public override OrderExpression VisitOrderByDefault([NotNull] CQLParser.OrderByDefaultContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            return new OrderExpression(SortOrder.Ascending, expression);
        }
    }
}