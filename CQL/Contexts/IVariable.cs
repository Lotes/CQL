using CQL.TypeSystem.Implementation;

namespace CQL.Contexts
{
    public interface IVariable<TAbstraction>
    {
        string Name { get; }
        TAbstraction Value { get; }
    }
}