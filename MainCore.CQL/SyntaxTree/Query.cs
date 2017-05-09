using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class Query: ISyntaxTreeNode
    {
        public readonly IExpression Expression;
        public readonly IEnumerable<OrderExpression> OrderByExpressions;
        public readonly IEnumerable<NamedExpression> SelectExpressions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="expression">not null</param>
        /// <param name="orderByExpressions">can be null</param>
        /// <param name="selectExpressions">can be null</param>
        public Query(ParserRuleContext context, IExpression expression, IEnumerable<OrderExpression> orderByExpressions = null, IEnumerable<NamedExpression> selectExpressions = null)
        {
            ParserContext = context;
            SelectExpressions = selectExpressions ?? Enumerable.Empty<NamedExpression>();
            Expression = expression;
            OrderByExpressions = orderByExpressions ?? Enumerable.Empty<OrderExpression>();
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as Query;
            if (other == null)
                return false;
            return this.Expression.StructurallyEquals(other.Expression)
                && this.OrderByExpressions.StructurallyEquals(other.OrderByExpressions)
                && this.SelectExpressions.StructurallyEquals(other.SelectExpressions);
        }

        public override string ToString()
        {
            return Expression.ToString()
                + (OrderByExpressions.Any() ? " ORDER BY "+string.Join(", ", OrderByExpressions.Select(o => o.ToString())) : "")
                + (SelectExpressions.Any() ? " SELECT "+string.Join(", ", SelectExpressions.Select(s => s.ToString())): "");
        }
    }
}
