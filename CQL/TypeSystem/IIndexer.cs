namespace CQL.TypeSystem
{
    public interface IIndexer
    {
        System.Type ReturnType { get; }
        System.Type[] FormalParameters { get; }
        object Get(object @this, params object[] indices);
        void Set(object @this, object[] indices, object value);
    }
}