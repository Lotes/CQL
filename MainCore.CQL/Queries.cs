using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;
using MainCore.CQL.SyntaxTree;
using MainCore.CQL.Visitors;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.Contexts;

namespace MainCore.CQL
{
    public static class Queries
    {
        public static Query ParseForSyntaxOnly(string text, IErrorListener errorListener = null)
        {
            var inputStream = new AntlrInputStream(text);
            var speakLexer = new CQLLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(speakLexer);
            var parser = new CQLParser(commonTokenStream);
            AddErrorListener(parser, errorListener);
            var parseContext = parser.query();
            var visitor = new QueryVisitor();
            return visitor.Visit(parseContext);
        }

        private static void AddErrorListener(this CQLParser parser, IErrorListener errorListener)
        {
            if (errorListener != null)
                parser.AddErrorListener(errorListener);
            else
            {
                errorListener = new ErrorListener();
                errorListener.ErrorDetected += (sender, ex) => { throw ex; };
                parser.AddErrorListener(errorListener);
            }
        }

        public static Query ParseSemantically(string text, IContext context, IErrorListener errorListener = null)
        {
            try
            {
                var query = ParseForSyntaxOnly(text);
                return query.Validate(context);
            }
            catch (LocateableException ex)
            {
                if (errorListener != null)
                {
                    errorListener.TriggerError(ex);
                    return null;
                }
                throw ex;
            }
        }

        public static bool? Evaluate<TSubject>(string text, TSubject subject, IContext context, IErrorListener errorListener = null)
        {
            try
            { 
                var query = ParseSemantically(text, context, errorListener);
                return query.Evaluate(subject);
            }
            catch (LocateableException ex)
            {
                if (errorListener != null)
                {
                    errorListener.TriggerError(ex);
                    return null;
                }
                throw ex;
            }
        }
    }
}
