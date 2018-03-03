using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace CQL.Visitors
{
    public class NameVisitor: CQLBaseVisitor<string>
    {
        public override string VisitMemberName([NotNull] CQLParser.MemberNameContext context)
        {
            return context.id.Text;
        }
        public override string VisitTypeName([NotNull] CQLParser.TypeNameContext context)
        {
            return context.castingType.Text;
        }

        public override string VisitTrue([NotNull] CQLParser.TrueContext context)
        {
            return context.value.Text;
        }

        public override string VisitFalse([NotNull] CQLParser.FalseContext context)
        {
            return context.value.Text;
        }

        public override string VisitPrimeVar([NotNull] CQLParser.PrimeVarContext context)
        {
            return context.var.Text;
        }
    }
}
