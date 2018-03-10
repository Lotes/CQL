using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class NativeMemberFunction : IMemberFunction
    {
        private MethodInfo method;

        public NativeMemberFunction(Type @this, MethodInfo method)
        {
            if (!@this.GetMethods().Contains(method))
                throw new InvalidOperationException("This is not a native method!");
            this.method = method;
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            Signature = new MethodSignature(@this, method.ReturnType, parameterTypes);
        }

        public MethodSignature Signature { get; private set; }

        public object Invoke(object @this, params object[] parameters)
        {
            return method.Invoke(@this, parameters);
        }
    }

    public abstract class ForeignMemberFunction : IMemberFunction
    {
        private Delegate body;
        public ForeignMemberFunction(Type thisType, Type[] formalParameters, Type returnType, Delegate body)
        {
            this.Signature = new MethodSignature(thisType, returnType, formalParameters);
            this.body = body;
        }

        public MethodSignature Signature { get; private set; }

        public object Invoke(object @this, params object[] parameters)
        {
            return body.DynamicInvoke(new[] { @this }.Concat(parameters).ToArray());
        }
    }
}
