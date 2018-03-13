using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// Abstract base class of all native global functions.
    /// </summary>
    public abstract class NativeGlobalFunction : IGlobalFunction
    {
        private MethodInfo method;

        /// <summary>
        /// Creates a native global function from a MethodInfo.
        /// </summary>
        /// <param name="method"></param>
        public NativeGlobalFunction(MethodInfo method)
        {
            this.method = method;
            if (!method.IsStatic || !method.IsPublic)
                throw new InvalidOperationException("Constructor only accepts static, public methods!");
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            Signature = new GlobalFunctionSignature(method.ReturnType, parameterTypes);
        }

        /// <summary>
        /// Type signature.
        /// </summary>
        public GlobalFunctionSignature Signature { get; private set; }

        /// <summary>
        /// Calls the native function using the concrete parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Invoke(params object[] parameters)
        {
            return method.Invoke(null, parameters);
        }
    }
}
