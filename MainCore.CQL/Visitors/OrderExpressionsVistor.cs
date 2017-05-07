using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MainCore.CQL.Visitors
{
    public class OrderExpressionsVistor: CQLBaseVisitor<IEnumerable<OrderExpression>>
    {
        public readonly OrderExpressionVisitor OrderExpressionVisitor;

        public OrderExpressionsVistor(OrderExpressionVisitor orderExpressionVisitor)
        {
            OrderExpressionVisitor = orderExpressionVisitor;
        }

        public override IEnumerable<OrderExpression> VisitOrderByConcat([NotNull] CQLParser.OrderByConcatContext context)
        {
            var list = Visit(context.firsts);
            var next = OrderExpressionVisitor.Visit(context.next);
            return list.Concat(new[] { next });
        }

        public override IEnumerable<OrderExpression> VisitOrderBySingle([NotNull] CQLParser.OrderBySingleContext context)
        {
            var last = OrderExpressionVisitor.Visit(context.last);
            return new[] { last };
        }
    }
}
