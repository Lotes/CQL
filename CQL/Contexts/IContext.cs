using CQL.TypeSystem;
using System.Collections.Generic;

namespace CQL.Contexts
{
    public interface IContext
    {
        ITypeSystem TypeSystem { get; }
        INameable Get(string name);
        IEnumerable<INameable> GetByPrefix(string prefix);
        IEnumerable<Field> Fields { get; }
        IEnumerable<AbstractFunction> Functions { get; }
        IEnumerable<Constant> Constants { get; }
    }
}
