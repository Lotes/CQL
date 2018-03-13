using System;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// A global function defined using a lambda function.
    /// </summary>
    public abstract class LambdaGlobalFunction : IGlobalFunction
    {
        private Delegate body;
        /// <summary>
        /// Abstract constructor.
        /// </summary>
        /// <param name="formalParameters"></param>
        /// <param name="returnType"></param>
        /// <param name="body"></param>
        public LambdaGlobalFunction(Type[] formalParameters, Type returnType, Delegate body)
        {
            this.Signature = new GlobalFunctionSignature(returnType, formalParameters);
            this.body = body;
        }

        /// <summary>
        /// Type signature of the function.
        /// </summary>
        public GlobalFunctionSignature Signature { get; private set; }

        /// <summary>
        /// Calls the global function.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Invoke(params object[] parameters)
        {
            return body.Method.Invoke(body.Target, parameters);
        }
    }
}
