using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// This, Parameters and Return type of a member function.
    /// </summary>
    public class IMemberFunctionSignature
    {
        /// <summary>
        /// Create a signature.
        /// </summary>
        /// <param name="thisType"></param>
        /// <param name="returnType"></param>
        /// <param name="parameterTypes"></param>
        public IMemberFunctionSignature(Type thisType, Type returnType, Type[] parameterTypes)
        {
            ThisType = thisType;
            ReturnType = returnType;
            ParameterTypes = parameterTypes;
        }

        /// <summary>
        /// This type
        /// </summary>
        public Type ThisType { get; private set; }
        /// <summary>
        /// Return type
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// Parameter types
        /// </summary>
        public Type[] ParameterTypes { get; private set; }
    }
}