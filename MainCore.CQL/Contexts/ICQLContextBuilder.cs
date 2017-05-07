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
    public interface ICQLContextBuilder
    {
        void AddField<THost, TField>(string name, Func<THost, TField> getter);
        void AddAggregationRule<TLeft, TRight, TResult>(BinaryOperator @operator, Func<TLeft, TRight, TResult> aggregate);
        void LinkTagCatalog(ITagCatalog tags);
        void LinkMetricKeyCatalog(IEnumerable<MetricKey> metricKeys);
        void AddFunction<TResult>(string name, Func<TResult> func);
        void AddFunction<TArg1, TResult>(string name, Func<TArg1, TResult> func);
        void AddFunction<TArg1, TArg2, TResult>(string name, Func<TArg1, TArg2, TResult> func);
        void AddFunction<TArg1, TArg2, TArg3, TResult>(string name, Func<TArg1, TArg2, TArg3, TResult> func);
        ICQLContext Build();
    }
}
