using MainCore.CQL.SyntaxTree;
using System.Collections;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using System.Linq;

namespace MainCore.CQL.Visitors
{
    public class ExpressionsVisitor: CQLBaseVisitor<IEnumerable<IExpression>>
    {
        private readonly ExpressionVisitor ExpressionVisitor;

        public ExpressionsVisitor(ExpressionVisitor exprVisitor)
        {
            this.ExpressionVisitor = exprVisitor;
        }
        public override IEnumerable<IExpression> VisitElemList([NotNull] CQLParser.ElemListContext context)
        {
            var list = Visit(context.elems);
            var next = ExpressionVisitor.Visit(context.next);
            return list.Concat(new[] { next });
        }
        public override IEnumerable<IExpression> VisitParamList([NotNull] CQLParser.ParamListContext context)
        {
            var list = Visit(context.elems);
            var next = ExpressionVisitor.Visit(context.next);
            return list.Concat(new[] { next });
        }
        public override IEnumerable<IExpression> VisitParamSingle([NotNull] CQLParser.ParamSingleContext context)
        {
            var last = ExpressionVisitor.Visit(context.expr);
            return new[] { last };
        }
        public override IEnumerable<IExpression> VisitElemSingle([NotNull] CQLParser.ElemSingleContext context)
        {
            var last = ExpressionVisitor.Visit(context.expr);
            return new[] { last };
        }
    }
}