namespace CQL.SyntaxTree
{
    /// <summary>
    /// Types of binary operation.
    /// </summary>
    public enum BinaryOperator
    {
        /// <summary>
        /// Logical OR
        /// </summary>
        Or,
        /// <summary>
        /// Logical AND
        /// </summary>
        And,
        /// <summary>
        /// Equality
        /// </summary>
        Equals,
        /// <summary>
        /// Negated equality
        /// </summary>
        NotEquals,
        /// <summary>
        /// Greater than relation
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Greater or equals relation
        /// </summary>
        GreaterThanEquals,
        /// <summary>
        /// Less than relation
        /// </summary>
        LessThan,
        /// <summary>
        /// Less or equals than relation.
        /// </summary>
        LessThanEquals,
        /// <summary>
        /// Addition of numerics or concat for strings
        /// </summary>
        Add,
        /// <summary>
        /// Substraction
        /// </summary>
        Sub,
        /// <summary>
        /// Multiplication
        /// </summary>
        Mul,
        /// <summary>
        /// Modulo
        /// </summary>
        Mod,
        /// <summary>
        /// Division
        /// </summary>
        Div,
        /// <summary>
        /// Contains check on strings
        /// </summary>
        Contains,
        /// <summary>
        /// Does not contain check on strings.
        /// </summary>
        DoesNotContain,
        /// <summary>
        /// Type and Null check
        /// </summary>
        Is,
        /// <summary>
        /// Element IN Array
        /// </summary>
        In,
        /// <summary>
        /// Element NOT IN Array
        /// </summary>
        NotIn
    }
}