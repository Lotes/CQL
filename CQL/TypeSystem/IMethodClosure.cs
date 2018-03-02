using CQL.TypeSystem.Implementation;
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
        object Invoke(params object[] parameters);
    }

    public interface IMethodClosure<TMethod>: IMethodClosure
        where TMethod: Method
    {
        TMethod Function { get; }
    }
}
