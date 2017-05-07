namespace MainCore.CQL.SyntaxTree
{
    public class OrderExpression
    {
        public readonly SortOrder Order;
        public readonly IExpression Expression;

        public OrderExpression(SortOrder order, IExpression expression)
        {
            Order = order;
            Expression = expression;
        }
    }
}