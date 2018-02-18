using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public abstract class Method : IMethod
    {
        private Delegate body;
        public Method(Type thisType, Type[] formalParameters, Type returnType, Delegate body)
        {
            this.ThisType = thisType;
            this.FormalParameters = formalParameters;
            this.ReturnType = returnType;
            this.body = body;
        }

        public IdDelimiter Delimiter { get; private set; }
        public Type[] FormalParameters { get; private set; }
        public Type ThisType { get; private set; }

        public string Name { get; private set; }
        public Type ReturnType { get; private set; }
        public object Invoke(object @this, params object[] parameters)
        {
            return body.Method.Invoke(null, new[] { @this }.Concat(parameters).ToArray());
        }
    }

    public class Method<TThis, TReturn> : Method
    {
        public Method(Func<TThis, TReturn> body) : base(typeof(TThis), new Type[0], typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1> : Method
    {
        public Method(Func<TThis, T1, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2> : Method
    {
        public Method(Func<TThis, T1, T2, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2, T3> : Method
    {
        public Method(Func<TThis, T1, T2, T3, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2), typeof(T3) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2, T3, T4> : Method
    {
        public Method(Func<TThis, T1, T2, T3, T4, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2, T3, T4, T5> : Method
    {
        public Method(Func<TThis, T1, T2, T3, T4, T5, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2, T3, T4, T5, T6> : Method
    {
        public Method(Func<TThis, T1, T2, T3, T4, T5, T6, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, typeof(TReturn), body)
        {
        }
    }

    public class Method<TThis, TReturn, T1, T2, T3, T4, T5, T6, T7> : Method
    {
        public Method(Func<TThis, T1, T2, T3, T4, T5, T6, T7, TReturn> body) : base(typeof(TThis), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, typeof(TReturn), body)
        {
        }
    }
}
