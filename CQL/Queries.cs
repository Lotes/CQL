using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;
using CQL.SyntaxTree;
using CQL.Visitors;
using CQL.ErrorHandling;
using CQL.Contexts;
using CQL.AutoCompletion;

namespace CQL
{
    public static class Queries
    {
        public static readonly Query True = new Query(ParserLocation.EmptyContext, new BooleanLiteralExpression(ParserLocation.EmptyContext, true));

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

        public static Query Parse(string text, IContext context, IErrorListener errorListener = null)
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

        public static IEnumerable<Suggestion> AutoComplete(string textUntilCaret, IContext context)
        {
            var suggester = new AutoCompletionSuggester(context);
            return suggester.GetSuggestions(textUntilCaret);
        }

        public static bool? Evaluate<TSubject>(string text, TSubject subject, IContext context, IErrorListener errorListener = null)
        {
            try
            { 
                var query = Parse(text, context, errorListener);
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
