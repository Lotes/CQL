namespace MainCore.CQL.SyntaxTree
{
    public enum BinaryOperator
    {
        Or, And,
        Equals, NotEquals,
        GreaterThan, GreaterThanEquals,
        LessThan, LessThanEquals,
        Add, Sub, Mul, Mod, Div,
        Contains, DoesNotContain,
        Is, IsNot,
        In, NotIn
    }
}