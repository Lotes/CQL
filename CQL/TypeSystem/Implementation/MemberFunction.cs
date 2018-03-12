using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// Native member functions are members of the original ("this") type.
    /// They are declared in the class definition of the THIS type.
    /// Use <see cref="CQLNativeMemberFunctionAttribute"/> attribute to
    /// mark a function for a type in the typesystem.
    /// </summary>
    public abstract class NativeMemberFunction : IMemberFunction
    {
        private MethodInfo method;

        /// <summary>
        /// Creates a native member function. Requires the actual THIS type and the 
        /// <see cref="System.Reflection.MemberInfo"/> of the requested function.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="method"></param>
        public NativeMemberFunction(Type @this, MethodInfo method)
        {
            if (!@this.GetMethods().Contains(method))
                throw new InvalidOperationException("This is not a native method!");
            this.method = method;
            var parameterTypes = method.GetParameters().Select(p => p.ParameterType).ToArray();
            Signature = new IMemberFunctionSignature(@this, method.ReturnType, parameterTypes);
        }

        /// <summary>
        /// Summarizes the signature of the function.
        /// </summary>
        public IMemberFunctionSignature Signature { get; private set; }

        /// <summary>
        /// Invokes the function by passing the THIS object and the parameter objects.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Invoke(object @this, params object[] parameters)
        {
            return method.Invoke(@this, parameters);
        }
    }

    /// <summary>
    /// Foreign member functions are lambda functions that extend types without changing
    /// its class definition.
    /// </summary>
    public abstract class ForeignMemberFunction : IMemberFunction
    {
        private Delegate body;
        /// <summary>
        /// Creates a foreign member function. Needs the interface types and a lambda 
        /// function with this signature.
        /// </summary>
        /// <param name="thisType"></param>
        /// <param name="formalParameters"></param>
        /// <param name="returnType"></param>
        /// <param name="body"></param>
        public ForeignMemberFunction(Type thisType, Type[] formalParameters, Type returnType, Delegate body)
        {
            this.Signature = new IMemberFunctionSignature(thisType, returnType, formalParameters);
            this.body = body;
        }

        /// <summary>
        /// The signature of the foreign member function.
        /// </summary>
        public IMemberFunctionSignature Signature { get; private set; }

        /// <summary>
        /// Calls the lambda function, passing the THIS object and the parameters.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object Invoke(object @this, params object[] parameters)
        {
            return body.DynamicInvoke(new[] { @this }.Concat(parameters).ToArray());
        }
    }
}
