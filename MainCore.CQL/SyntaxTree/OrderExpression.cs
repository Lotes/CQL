using Antlr4.Runtime;
using System;

namespace MainCore.CQL.SyntaxTree
{
    public class OrderExpression: ISyntaxTreeNode
    {
        public readonly SortOrder Order;
        public readonly IExpression Expression;

        public OrderExpression(ParserRuleContext context, SortOrder order, IExpression expression)
        {
            ParserContext = context;
            Order = order;
            Expression = expression;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public override string ToString()
        {
            var order = Order == SortOrder.Ascending ? "ASC" : "DESC";
            return $"{Expression.ToString()} {order}";
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as OrderExpression;
            if (other == null)
                return false;
            return this.Order == other.Order
                && this.Expression.StructurallyEquals(other.Expression);
        }
    }
}