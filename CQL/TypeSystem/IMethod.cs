namespace CQL.TypeSystem
{
    public interface IMethod: ISymbol
    {
        object Invoke(object @this, params object[] parameters);
    }
}