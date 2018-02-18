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

        public static IMethodClosure<TMethod> BindThis<TMethod>(this TMethod method, object @this)
            where TMethod: Method
        {
            if (!method.ThisType.IsAssignableFrom(@this.GetType()))
                throw new InvalidOperationException("Type mismatch on this!");
            return new Closure<TMethod>(@this, method); 
        }
    }
}
