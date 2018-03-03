using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public abstract class Function : IFunction
    {
        private Delegate body;
        public Function(Type[] formalParameters, Type returnType, Delegate body)
        {
            this.Signature = new FunctionSignature(returnType, formalParameters);
            this.body = body;
        }

        public FunctionSignature Signature { get; private set; }

        public object Invoke(params object[] parameters)
        {
            return body.Method.Invoke(body.Target, parameters);
        }
    }

    public class Function<TReturn> : Function
    {
        public Function(Func<TReturn> body) : base(new Type[0], typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1> : Function
    {
        public Function(Func<T1, TReturn> body) : base(new Type[] { typeof(T1) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2> : Function
    {
        public Function(Func<T1, T2, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2, T3> : Function
    {
        public Function(Func<T1, T2, T3, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2, T3, T4> : Function
    {
        public Function(Func<T1, T2, T3, T4, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2, T3, T4, T5> : Function
    {
        public Function(Func<T1, T2, T3, T4, T5, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2, T3, T4, T5, T6> : Function
    {
        public Function(Func<T1, T2, T3, T4, T5, T6, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, typeof(TReturn), body)
        {
        }
    }

    public class Function<TReturn, T1, T2, T3, T4, T5, T6, T7> : Function
    {
        public Function(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, typeof(TReturn), body)
        {
        }
    }
}
