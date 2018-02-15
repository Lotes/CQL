using CQL.SyntaxTree;

namespace CQL.TypeSystem
{
    public interface IMethod: ISymbol
    {
        System.Type[] FormalParameters { get; }
        System.Type ReturnType { get; }
        IdDelimiter Delimiter { get; }
        object Invoke(object @this, params object[] parameters);
    }
}