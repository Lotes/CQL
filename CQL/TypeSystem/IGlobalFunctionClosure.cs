namespace CQL.TypeSystem
{
    /// <summary>
    /// The closure of a global function...
    /// </summary>
    public interface IGlobalFunctionClosure
    {
        /// <summary>
        /// Calls the bound global function.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object Invoke(params object[] parameters);
    }
}
