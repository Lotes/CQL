using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MainCore.CQL.Visitors
{
    public class NamedExpressionsVisitor: CQLBaseVisitor<IEnumerable<NamedExpression>>
    {
        public readonly NamedExpressionVisitor NamedExpressionVisitor;

        public NamedExpressionsVisitor(NamedExpressionVisitor namedExpressionVisitor)
        {
            NamedExpressionVisitor = namedExpressionVisitor;
        }

        public override IEnumerable<NamedExpression> VisitSelectConcat([NotNull] CQLParser.SelectConcatContext context)
        {
            var firsts = Visit(context.firsts);
            var next = NamedExpressionVisitor.Visit(context.next);
            return firsts.Concat(new[] { next });
        }
        public override IEnumerable<NamedExpression> VisitSelectSingle([NotNull] CQLParser.SelectSingleContext context)
        {
            var last = NamedExpressionVisitor.Visit(context.last);
            return new[] { last };
        }
    }
}
