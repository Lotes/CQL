using MainCore.Metrics;
using MainCore.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public interface IContext
    {
        IEnumerable<Tag> Tags { get; }
        IEnumerable<MetricKey> MetricKeys { get; }
        IRuleSet Rules { get; }
        IFunctionSet Functions { get; }
        IFieldSet Fields { get; }
    }
}
