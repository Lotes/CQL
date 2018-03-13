using CQL.SyntaxTree;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using System.Linq;

namespace CQL.Visitors
{
    /// <summary>
    /// Visitor that produces a list of expressions.
    /// </summary>
    public class ExpressionsVisitor: CQLBaseVisitor<IEnumerable<IExpression>>
    {
        private readonly ExpressionVisitor ExpressionVisitor;

        /// <summary>
        /// Creates a visitor producing lists of expressions, like parameter list etc.
        /// </summary>
        /// <param name="exprVisitor"></param>
        public ExpressionsVisitor(ExpressionVisitor exprVisitor)
        {
            this.ExpressionVisitor = exprVisitor;
        }
        /// <summary>
        /// Returns expression list from parser's <see cref="CQLParser.ElemListContext"/>.
        /// Represents a list of multiple expressions.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<IExpression> VisitElemList([NotNull] CQLParser.ElemListContext context)
        {
            var list = Visit(context.elems);
            var next = ExpressionVisitor.Visit(context.next);
            return list.Concat(new[] { next });
        }
        /// <summary>
        /// Returns expression list from parser's <see cref="CQLParser.ParamListContext"/>.
        /// Represents multiple expressions in a parameter list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<IExpression> VisitParamList([NotNull] CQLParser.ParamListContext context)
        {
            var list = Visit(context.elems);
            var next = ExpressionVisitor.Visit(context.next);
            return list.Concat(new[] { next });
        }
        /// <summary>
        /// Returns expression list from parser's <see cref="CQLParser.ParamSingleContext"/>.
        /// Represents one expression of a parameter list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<IExpression> VisitParamSingle([NotNull] CQLParser.ParamSingleContext context)
        {
            var last = ExpressionVisitor.Visit(context.expr);
            return new[] { last };
        }
        /// <summary>
        /// Returns expression list from parser's <see cref="CQLParser.ElemSingleContext"/>.
        /// Represents one expression of a list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<IExpression> VisitElemSingle([NotNull] CQLParser.ElemSingleContext context)
        {
            var last = ExpressionVisitor.Visit(context.expr);
            return new[] { last };
        }
    }
}