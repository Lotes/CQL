using MainCore.CQL.TypeSystem;
using System.Collections.Generic;

namespace MainCore.CQL.Contexts
{
    public interface IContext
    {
        ITypeSystem TypeSystem { get; }
        INameable Get(string name);
        IEnumerable<INameable> GetByPrefix(string prefix);
    }
}
