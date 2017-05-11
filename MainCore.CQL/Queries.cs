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

namespace MainCore.CQL
{
    public static class Queries
    {
        private class ErrorListener : IAntlrErrorListener<IToken>
        {
            public readonly Action<IRecognizer, IToken, int, int, string, RecognitionException> Action;

            public ErrorListener(Action<IRecognizer, IToken, int, int, string, RecognitionException> action)
            {
                Action = action;
            }

            public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                Action(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            }
        }
        private static void AddErrorListener(this CQLParser @this, Action<IRecognizer, IToken, int, int, string, RecognitionException> action)
        {
            @this.AddErrorListener(new ErrorListener(action));
        }
        public static Query Parse(string text)
        {
            var inputStream = new AntlrInputStream(text);
            var speakLexer = new CQLLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(speakLexer);
            var parser = new CQLParser(commonTokenStream);
            var errors = new List<LocateableException>();
            parser.AddErrorListener((recognizer, offendingSymbol, line, charPositionInLine, msg, e) =>
            {
                errors.Add(new LocateableException(offendingSymbol.StartIndex, offendingSymbol.StopIndex, msg, e));
            });
            var parseContext = parser.query();
            var visitor = new QueryVisitor();
            var result = visitor.Visit(parseContext);
            if (errors.Any())
            {
                var ex = errors.First();
                throw ex;
            }
            return result;
        }
    }
}
