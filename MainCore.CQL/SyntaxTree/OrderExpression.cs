using Antlr4.Runtime;
using System;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class OrderExpression: ISyntaxTreeNode<OrderExpression>
    {
        public readonly SortOrder Order;
        public IExpression Expression { get; private set; }

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

        public OrderExpression Validate(IContext context)
        {
            Expression = Expression.Validate(context);
            if (!(Expression.SemanticType is IComparable))
                throw new LocateableException(ParserContext.Start.StartIndex, ParserContext.Stop.StopIndex, "Resulting type must be comparable!");
            return this;
        }
    }
}