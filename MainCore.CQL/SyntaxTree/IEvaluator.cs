using MainCore.CQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public interface IEvaluator
    {
        object Evaluate(object input, IContext context);
    }

    public interface IEvaluator<TInput, TResult>: IEvaluator
    {
        TResult Evaluate(TInput input, IContext context);
    }
}
