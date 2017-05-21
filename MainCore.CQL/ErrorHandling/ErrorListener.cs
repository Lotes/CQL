using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.ErrorHandling
{
    public class ErrorListener : IErrorListener
    {
        public event EventHandler<LocateableException> ErrorDetected;

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            TriggerError(new LocateableException(offendingSymbol.StartIndex, offendingSymbol.StopIndex, msg, e));
        }

        public void TriggerError(LocateableException error)
        {
            if (ErrorDetected != null)
                ErrorDetected(this, error);
        }
    }
}
