using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace CQL.Visitors
{
    public class QueryVisitor: CQLBaseVisitor<Query>
    {
        private ExpressionVisitor expressionVisitor;

        public QueryVisitor()
        {
            expressionVisitor = new ExpressionVisitor();
        }

        public override Query VisitQuery([NotNull] CQLParser.QueryContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            return new Query((ParserLocation)context, expression);
        }
    }
}
