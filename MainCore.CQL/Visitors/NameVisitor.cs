using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace MainCore.CQL.Visitors
{
    public class NameVisitor: CQLBaseVisitor<string>
    {
        public override string VisitVariableName([NotNull] CQLParser.VariableNameContext context)
        {
            return context.id.Text;
        }

        public override string VisitTypeName([NotNull] CQLParser.TypeNameContext context)
        {
            return context.castingType.Text;
        }

        public override string VisitFunctionName([NotNull] CQLParser.FunctionNameContext context)
        {
            return context.name.Text;
        }
    }
}
