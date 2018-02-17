using CQL.SyntaxTree;

namespace CQL.TypeSystem
{
    public interface IMethod
    {
        System.Type[] FormalParameters { get; }
        System.Type ReturnType { get; }
        System.Type ThisType { get; }
        IdDelimiter Delimiter { get; }
        object Invoke(object @this, params object[] parameters);
    }
}