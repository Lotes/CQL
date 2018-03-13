using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Signatrue of a glbal function.
    /// </summary>
    public class GlobalFunctionSignature
    {
        /// <summary>
        /// Creates a type signature of a global function.
        /// </summary>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        public GlobalFunctionSignature(Type returnType, Type[] parameterTypes)
        {
            ReturnType = returnType;
            ParameterTypes = parameterTypes;
        }

        /// <summary>
        /// the return type.
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// The parameter types.
        /// </summary>
        public Type[] ParameterTypes { get; private set; }
    }
}
