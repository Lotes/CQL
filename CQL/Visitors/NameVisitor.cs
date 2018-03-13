using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace CQL.Visitors
{
    /// <summary>
    /// Visitor producing <see cref="System.String"/> names from parts of the abstract syntax tree (AST).
    /// </summary>
    public class NameVisitor: CQLBaseVisitor<string>
    {
        /// <summary>
        /// Returns name from parser's <see cref="CQLParser.MemberNameContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string VisitMemberName([NotNull] CQLParser.MemberNameContext context)
        {
            return context.id.Text;
        }
        /// <summary>
        /// Returns name from parser's <see cref="CQLParser.TypeNameContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string VisitTypeName([NotNull] CQLParser.TypeNameContext context)
        {
            return context.castingType.Text;
        }
        /// <summary>
        /// Returns name from parser's <see cref="CQLParser.TrueContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string VisitTrue([NotNull] CQLParser.TrueContext context)
        {
            return context.value.Text;
        }
        /// <summary>
        /// Returns name from parser's <see cref="CQLParser.FalseContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string VisitFalse([NotNull] CQLParser.FalseContext context)
        {
            return context.value.Text;
        }
        /// <summary>
        /// Returns name from parser's <see cref="CQLParser.PrimeVarContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string VisitPrimeVar([NotNull] CQLParser.PrimeVarContext context)
        {
            return context.var.Text;
        }
    }
}
