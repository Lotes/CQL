using CQL.TypeSystem.Implementation;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Describes a global function.
    /// </summary>
    public interface IGlobalFunction
    {
        /// <summary>
        /// Type signature of this function.
        /// </summary>
        GlobalFunctionSignature Signature { get; }
        /// <summary>
        /// Calls the function by passing concrete parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object Invoke(params object[] parameters);
    }

    /// <summary>
    /// Generic variant of <see cref="IGlobalFunctionClosure"/>
    /// </summary>
    /// <typeparam name="TFunction"></typeparam>
    public interface IGlobalFunctionClosure<TFunction> : IGlobalFunctionClosure
        where TFunction : IGlobalFunction
    {
        /// <summary>
        /// The bound global function.
        /// </summary>
        TFunction Function { get; }
    }
}
