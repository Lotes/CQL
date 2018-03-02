using CQL.TypeSystem.Implementation;
using System;

namespace CQL.TypeSystem
{
    public interface IFunction
    {
        FunctionSignature Signature { get; }
        object Invoke(params object[] parameters);
    }

    public class FunctionSignature
    {
        public FunctionSignature(Type returnType, Type[] parameterTypes)
        {
            ReturnType = returnType;
            ParameterTypes = parameterTypes;
        }

        public Type ReturnType { get; private set; }
        public Type[] ParameterTypes { get; private set; }
    }

    public interface IFunctionClosure
    {
        object Invoke(params object[] parameters);
    }

    public interface IFunctionClosure<TFunction> : IFunctionClosure
        where TFunction : Function
    {
        TFunction Function { get; }
    }
}
