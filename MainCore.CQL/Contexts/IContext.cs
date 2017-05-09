using MainCore.CQL.TypeSystem;

namespace MainCore.CQL.Contexts
{
    public interface IContext
    {
        ITypeSystem TypeSystem { get; }
        IFunctionSet Functions { get; }
        IFieldSet Fields { get; }
    }
}
