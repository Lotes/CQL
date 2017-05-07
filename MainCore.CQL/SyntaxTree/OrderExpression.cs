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

        public override string ToString()
        {
            var order = Order == SortOrder.Ascending ? "ASC" : "DESC";
            return $"{Expression.ToString()} {order}";
        }
    }
}