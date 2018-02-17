using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IMethodClosure
    {
        object ThisObject { get; }
        IMethod Method { get; }
        object Invoke(params object[] parameters);
    }
}
