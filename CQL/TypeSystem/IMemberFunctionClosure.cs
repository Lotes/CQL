using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IMemberFunctionClosure
    {
        object ThisObject { get; }
        object Invoke(params object[] parameters);
    }

    public interface IMemberFunctionClosure<TMemberFunction>: IMemberFunctionClosure
        where TMemberFunction : IMemberFunction
    {
        TMemberFunction Function { get; }
    }
}
