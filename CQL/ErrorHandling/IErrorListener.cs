using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.ErrorHandling
{
    /// <summary>
    /// Listens to ANTLR errors and forwards them as LocateableExceptions (<see cref="CQL.ErrorHandling.LocateableException"/>).
    /// </summary>
    public interface IErrorListener : IAntlrErrorListener<IToken>
    {
        /// <summary>
        /// Will be fired, when an ANTLR error was detected.
        /// </summary>
        event EventHandler<LocateableException> ErrorDetected;
        /// <summary>
        /// Fires a locateable exception via the <see cref="ErrorDetected"/> event.
        /// </summary>
        /// <param name="error"></param>
        void TriggerError(LocateableException error);
    }
}
