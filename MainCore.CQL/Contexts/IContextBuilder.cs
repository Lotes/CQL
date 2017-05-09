using MainCore.CQL.Contexts.Implementation;
using MainCore.CQL.SyntaxTree;
using MainCore.Metrics;
using MainCore.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public interface IContextBuilder
    {
        void AddField<THost, TField>(string name, Func<THost, TField> getter);
        void AddEqualsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        void AddContainsRule<TLeft, TRight>(Func<TLeft, TRight, bool> aggregate);
        void AddLessRule<TOperand>(Func<TOperand, TOperand, bool> aggregate);
        void LinkTagCatalog(ITagCatalog tags);
        void LinkMetricKeyCatalog(IEnumerable<MetricKey> metricKeys);
        FunctionSet.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage);
        IContext Build();
    }
}
