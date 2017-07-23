using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace MainCore.CQL.AutoCompletion
{
    /*public class ErrorListener: BaseErrorListener
    {
        public static void Install(CQLLexer lexer)
        {
            new ErrorListener(lexer);
        }

        private CQLLexer lexer;

        private ErrorListener(CQLLexer lexer)
            : base()
        {
            this.lexer = lexer;
            lexer.AddErrorListener(this);
        }

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Console.WriteLine();
        }
    }*/
}
