using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.ErrorHandling
{
    /// <summary>
    /// Concrete error listener to wrap ANTLR exceptions to locateable exception.
    /// </summary>
    public class ErrorListener : IErrorListener
    {
        /// <summary>
        /// Event to inform the user of ANTLR and locateable exceptions.
        /// </summary>
        public event EventHandler<LocateableException> ErrorDetected;

        /// <summary>
        /// Will be called by ANTLR when a syntax error was detected. Wraps the error into a locateable exception.
        /// </summary>
        /// <param name="recognizer"></param>
        /// <param name="offendingSymbol"></param>
        /// <param name="line"></param>
        /// <param name="charPositionInLine"></param>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            TriggerError(new LocateableException(offendingSymbol.StartIndex, offendingSymbol.StopIndex, msg, e));
        }

        /// <summary>
        /// Triggers <see cref="ErrorDetected"/> event with given exception.
        /// </summary>
        /// <param name="error"></param>
        public void TriggerError(LocateableException error)
        {
            ErrorDetected?.Invoke(this, error);
        }
    }
}
