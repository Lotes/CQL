namespace MainCore.CQL.SyntaxTree
{
    public enum BinaryOperator
    {
        //bools (and tags) only
        Or, And,
        //type has equals
        Equals, NotEquals,
        //type is a comparable
        GreaterThan, GreaterThanEquals, LessThan, LessThanEquals,
        //numerics and Add for strings
        Add, Sub, Mul, Mod, Div,
        //Strings/Regexs
        Contains, DoesNotContain,
        //Types/Null/Empty
        Is, IsNot,
        //Array
        In, NotIn
    }
}