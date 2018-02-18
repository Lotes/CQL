using CQL.SyntaxTree;
using System;

namespace CQL.TypeSystem
{
    public interface IMethod
    {
        MethodSignature Signature { get; }
        object Invoke(object @this, params object[] parameters);
    }

    public class MethodSignature
    {
        public MethodSignature(Type thisType, Type returnType, Type[] parameterTypes)
        {
            ThisType = thisType;
            ReturnType = returnType;
            ParameterTypes = parameterTypes;
        }

        public Type ThisType { get; private set; }
        public Type ReturnType { get; private set; }
        public Type[] ParameterTypes { get; private set; }
    }
}