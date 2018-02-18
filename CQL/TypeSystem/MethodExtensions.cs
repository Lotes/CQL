using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public static class MethodExtensions
    {
        private class Closure<TMethod> : IMethodClosure<TMethod>
            where TMethod: Method
        {
            public Closure(object @this, TMethod method)
            {
                ThisObject = @this;
                Method = method;
            }
            public TMethod Method { get; private set; }
            public object ThisObject { get; private set; }
            public object Invoke(params object[] parameters)
            {
                return Method.Invoke(ThisObject, parameters);
            }
        }

        public static bool IfMethodClosureTryGetMethodType(this Type @this, out MethodSignature signature)
        {
            signature = null;
            var closure = @this.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMethodClosure<>));
            if (closure == null)
                return false;
            var methodType = closure.GetGenericArguments()[0];
            var arguments = methodType.GetGenericArguments();
            signature = new MethodSignature(arguments[0], arguments[1], arguments.Skip(2).ToArray()); // by convention
            return true;
        }

        public static IMethodClosure<TMethod> BindThis<TMethod>(this TMethod method, object @this)
            where TMethod: Method
        {
            if (!method.Signature.ThisType.IsAssignableFrom(@this.GetType()))
                throw new InvalidOperationException("Type mismatch on this!");
            return new Closure<TMethod>(@this, method); 
        }
    }
}
