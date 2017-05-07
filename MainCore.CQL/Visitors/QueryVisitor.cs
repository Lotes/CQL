using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MainCore.CQL.Visitors
{
    public class QueryVisitor: CQLBaseVisitor<Query>
    {
        private ExpressionVisitor expressionVisitor;
        private OrderExpressionsVistor orderExpressionsVisitor;
        private NamedExpressionsVisitor namedExpressionsVisitor;

        public QueryVisitor()
        {
            expressionVisitor = new ExpressionVisitor();
            orderExpressionsVisitor = new OrderExpressionsVistor(new OrderExpressionVisitor(expressionVisitor));
            namedExpressionsVisitor = new NamedExpressionsVisitor(new NamedExpressionVisitor(expressionVisitor));
        }

        public override Query VisitQuery([NotNull] CQLParser.QueryContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            var orderExpressions = context.order == null ? Enumerable.Empty<OrderExpression>() : this.orderExpressionsVisitor.Visit(context.order.exprs);
            var selectExpressions = context.selection == null ? Enumerable.Empty<NamedExpression>() : this.namedExpressionsVisitor.Visit(context.selection.exprs);
            return new Query(expression, orderExpressions);
        }
    }
}
