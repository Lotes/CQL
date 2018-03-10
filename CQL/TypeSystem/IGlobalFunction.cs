using CQL.TypeSystem.Implementation;
using System;

namespace CQL.TypeSystem
{
    public interface IGlobalFunction
    {
        GlobalFunctionSignature Signature { get; }
        object Invoke(params object[] parameters);
    }

    public class GlobalFunctionSignature
    {
        public GlobalFunctionSignature(Type returnType, Type[] parameterTypes)
        {
            ReturnType = returnType;
            ParameterTypes = parameterTypes;
        }

        public Type ReturnType { get; private set; }
        public Type[] ParameterTypes { get; private set; }
    }

    public interface IGlobalFunctionClosure
    {
        object Invoke(params object[] parameters);
    }

    public interface IFunctionClosure<TFunction> : IGlobalFunctionClosure
        where TFunction : IGlobalFunction
    {
        TFunction Function { get; }
    }
}
