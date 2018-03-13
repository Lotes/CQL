using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Extensions for <see cref="IMemberFunction"/>.
    /// </summary>
    public static class MethodExtensions
    {
        private class Closure<TMemberFunction> : IMemberFunctionClosure<TMemberFunction>
            where TMemberFunction: IMemberFunction
        {
            public Closure(object @this, TMemberFunction method)
            {
                ThisObject = @this;
                Function = method;
            }
            public TMemberFunction Function { get; private set; }
            public object ThisObject { get; private set; }
            public object Invoke(params object[] parameters)
            {
                return Function.Invoke(ThisObject, parameters);
            }
        }
        /// <summary>
        /// Check type if it is a member function.
        /// Returns true and a signature if that is the case. FALSE otherwise.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static bool IfMemberFunctionClosureTryGetMethodSignature(this Type @this, out IMemberFunctionSignature signature)
        {
            signature = null;
            var closure = @this.GetInterfaces().Plus(@this).FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMemberFunctionClosure<>));
            if (closure == null)
                return false;
            var methodType = closure.GetGenericArguments()[0];
            var arguments = methodType.GetGenericArguments();
            signature = new IMemberFunctionSignature(arguments[0], arguments.Last(), arguments.Skip(1).Take(arguments.Count()-2).ToArray()); // by convention
            return true;
        }

        /// <summary>
        /// Checks whether THIS is a global function closure and returns TRUE with a signature if it is the case, otherwise FALSE.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static bool IfFunctionClosureTryGetFunctionType(this Type @this, out GlobalFunctionSignature signature)
        {
            signature = null;
            var closure = @this.GetInterfaces().Plus(@this).FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGlobalFunctionClosure<>));
            if (closure == null)
                return false;
            var functionType = closure.GetGenericArguments()[0];
            var arguments = functionType.GetGenericArguments();
            signature = new GlobalFunctionSignature(arguments[0], arguments.Skip(1).ToArray()); // by convention
            return true;
        }

        /// <summary>
        /// Binds a member function to a THIS object resulting in a <see cref="IMemberFunctionClosure"/>
        /// </summary>
        /// <typeparam name="TMemberFunction"></typeparam>
        /// <param name="function"></param>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IMemberFunctionClosure<TMemberFunction> BindThis<TMemberFunction>(this TMemberFunction function, object @this)
            where TMemberFunction: IMemberFunction
        {
            if (!function.Signature.ThisType.IsAssignableFrom(@this.GetType()))
                throw new InvalidOperationException("Type mismatch on this!");
            return new Closure<TMemberFunction>(@this, function); 
        }
    }
}
