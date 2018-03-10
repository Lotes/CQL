using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public abstract class LambdaGlobalFunction : IGlobalFunction
    {
        private Delegate body;
        public LambdaGlobalFunction(Type[] formalParameters, Type returnType, Delegate body)
        {
            this.Signature = new GlobalFunctionSignature(returnType, formalParameters);
            this.body = body;
        }

        public GlobalFunctionSignature Signature { get; private set; }

        public object Invoke(params object[] parameters)
        {
            return body.Method.Invoke(body.Target, parameters);
        }
    }

    public abstract class NativeGlobalFunction : IGlobalFunction
    {
        private MethodInfo method;

        public NativeGlobalFunction(MethodInfo method)
        {
            this.method = method;
            if (!method.IsStatic || !method.IsPublic)
                throw new InvalidOperationException("Constructor only accepts static, public methods!");
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            Signature = new GlobalFunctionSignature(method.ReturnType, parameterTypes);
        }

        public GlobalFunctionSignature Signature { get; private set; }

        public object Invoke(params object[] parameters)
        {
            return method.Invoke(null, parameters);
        }
    }
}
