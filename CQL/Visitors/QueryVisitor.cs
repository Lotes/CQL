using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace CQL.Visitors
{
    /// <summary>
    /// Visitor producing <see cref="Query"/> objects from parts of the abstract syntax tree (AST).
    /// </summary>
    public class QueryVisitor: CQLBaseVisitor<Query>
    {
        private ExpressionVisitor expressionVisitor;

        /// <summary>
        /// Creates a query visitor.
        /// </summary>
        public QueryVisitor()
        {
            expressionVisitor = new ExpressionVisitor();
        }

        /// <summary>
        /// Returns query from parser's <see cref="CQLParser.QueryContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Query VisitQuery([NotNull] CQLParser.QueryContext context)
        {
            var expression = expressionVisitor.Visit(context.expr);
            return new Query((ParserLocation)context, expression);
        }
    }
}
