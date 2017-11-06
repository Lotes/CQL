using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.ErrorHandling
{
    public interface IErrorListener : IAntlrErrorListener<IToken>
    {
        event EventHandler<LocateableException> ErrorDetected;
        void TriggerError(LocateableException error);
    }
}
