using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public static class MethodExtensions
    {
        private class Closure: IMethodClosure
        {
            public Closure(object @this, IMethod method)
            {
                ThisObject = @this;
                Method = method;
            }
            public IMethod Method { get; private set; }
            public object ThisObject { get; private set; }
            public object Invoke(params object[] parameters)
            {
                return Method.Invoke(ThisObject, parameters);
            }
        }

        public static IMethodClosure BindThis(this IMethod method, object @this)
        {
            if (!method.ThisType.IsAssignableFrom(@this.GetType()))
                throw new InvalidOperationException("Type mismatch on this!");
            return new Closure(@this, method); 
        }
    }
}
