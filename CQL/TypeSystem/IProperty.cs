namespace CQL.TypeSystem
{
    public interface IProperty: ISymbol
    {
        object Get(object @this);
        void Set(object @this, object value);
    }
}