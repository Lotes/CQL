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
        public readonly IEnumerable<NamedExpression> SelectExpressions;

        public Query(IExpression expression, IEnumerable<OrderExpression> orderByExpressions, IEnumerable<NamedExpression> selectExpressions)
        {
            SelectExpressions = selectExpressions;
            Expression = expression;
            OrderByExpressions = orderByExpressions;
        }

        public override string ToString()
        {
            return Expression.ToString()
                + (OrderByExpressions.Any() ? " ORDER BY "+string.Join(", ", OrderByExpressions.Select(o => o.ToString())) : "")
                + (SelectExpressions.Any() ? " SELECT "+string.Join(", ", SelectExpressions.Select(s => s.ToString())): "");
        }
    }
}
