using CQL.SyntaxTree;

namespace CQL.TypeSystem
{
    /// <summary>
    /// A non-global function belonging to a type.
    /// </summary>
    public interface IMemberFunction
    {
        /// <summary>
        /// This, Parameters and Return type of this function.
        /// </summary>
        IMemberFunctionSignature Signature { get; }
        /// <summary>
        /// Call the function by passing THIS and PARAMETERS.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object Invoke(object @this, params object[] parameters);
    }
}