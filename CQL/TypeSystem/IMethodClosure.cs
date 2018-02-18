using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IMethodClosure<TMethod>
        where TMethod: Method
    {
        object ThisObject { get; }
        TMethod Method { get; }
        object Invoke(params object[] parameters);
    }
}
