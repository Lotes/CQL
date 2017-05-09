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
        IFunction Get(string name);
    }
}
