namespace CQL.TypeSystem
{
    public interface IIndexer
    {
        System.Type ReturnType { get; }
        System.Type[] FormalParameters { get; }
        object Get(object @this, params object[] indices);
    }
}