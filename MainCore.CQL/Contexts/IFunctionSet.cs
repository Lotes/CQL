using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.Metrics;

namespace MainCore.CQL.Contexts
{
    public interface IFunctionSet
    {
        Func<object> Get(string name);
        Func<object, object> Get<TArg1>(string name);
        Func<object, object, object> Get<TArg1, TArg2>(string name);
        Func<object, object, object, object> Get<TArg1, TArg2, TArg3>(string name);
    }
}
