using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// A closure (THIS + FUNCTION) for a member function.
    /// </summary>
    public interface IMemberFunctionClosure
    {
        /// <summary>
        /// THIS bound to a member function.
        /// </summary>
        object ThisObject { get; }
        /// <summary>
        /// Invoke function by passing the parameters only.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object Invoke(params object[] parameters);
    }

    /// <summary>
    /// Generic variant of <see cref="IMemberFunctionClosure"/>. Used in the validation 
    /// process to reconstruct the function signature.
    /// </summary>
    /// <typeparam name="TMemberFunction"></typeparam>
    public interface IMemberFunctionClosure<TMemberFunction>: IMemberFunctionClosure
        where TMemberFunction : IMemberFunction
    {
        /// <summary>
        /// The actual function bound to this closure.
        /// </summary>
        TMemberFunction Function { get; }
    }
}
