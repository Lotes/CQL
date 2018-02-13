using CQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.SyntaxTree
{
    public interface IEvaluator
    {
        object Evaluate<TSubject>(IContext<object> context, TSubject @this);
    }
}
