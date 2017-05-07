using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class Query
    {
        public readonly IExpression Expression;
        public readonly IEnumerable<OrderExpression> OrderByExpressions;

        public Query(IExpression expression, IEnumerable<OrderExpression> orderByExpressions)
        {
            Expression = expression;
            OrderByExpressions = orderByExpressions;
        }
    }
}
