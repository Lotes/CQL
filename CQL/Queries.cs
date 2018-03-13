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
using CQL.Contexts.Implementation;

namespace CQL
{
    /// <summary>
    /// A facade for the user to quickly access the parser and evaluation API.
    /// </summary>
    public static class Queries
    {
        /// <summary>
        /// A query that returns true.
        /// </summary>
        public static readonly Query True = new Query(ParserLocation.EmptyContext, new BooleanLiteralExpression(ParserLocation.EmptyContext, true));

        /// <summary>
        /// Parses a user query (without validating it). You practically only get the syntax tree.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="errorListener"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Parses AND validates a query string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        /// <param name="errorListener"></param>
        /// <returns></returns>
        public static Query Parse(string text, IEvaluationScope context, IErrorListener errorListener = null)
        {
            try
            {
                var query = ParseForSyntaxOnly(text);
                return query.Validate(context.ToValidationScope());
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

        /// <summary>
        /// Trys to complete the user input by a given context.
        /// </summary>
        /// <param name="textUntilCaret"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IEnumerable<Suggestion> AutoComplete(string textUntilCaret, IEvaluationScope context)
        {
            var suggester = new AutoCompletionSuggester(context);
            return suggester.GetSuggestions(textUntilCaret);
        }

        /// <summary>
        /// Evaluates a user query string with a given context and an optional error listener.
        /// If no listener is given, this method will throw exceptions instead.
        /// Do not use this method if you want to evaluate a query for multiple subjects.
        /// Use <see cref="Parse(string, IEvaluationScope, IErrorListener)"/> instead in combination
        /// with <see cref="Query.Evaluate(IEvaluationScope)"/>.
        /// </summary>
        /// <typeparam name="TSubject"></typeparam>
        /// <param name="text"></param>
        /// <param name="subject"></param>
        /// <param name="context"></param>
        /// <param name="errorListener"></param>
        /// <returns></returns>
        public static bool? Evaluate<TSubject>(string text, TSubject subject, IEvaluationScope context, IErrorListener errorListener = null)
        {
            try
            {
                context.DefineThis(subject);
                var query = Parse(text, context, errorListener);
                return query.Evaluate(context);
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
