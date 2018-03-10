using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class LambdaGlobalFunction<TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<TReturn> body) : base(new Type[0], typeof(TReturn), body)
        {
        }
    }

	public class LambdaGlobalFunction<T1, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, TReturn> body) : base(new Type[] { typeof(T1) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) }, typeof(TReturn), body)
        {
        }
    }
	public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : LambdaGlobalFunction
    {
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) }, typeof(TReturn), body)
        {
        }
    }
	}