using CQL.SyntaxTree;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<TReturn> : LambdaGlobalFunction
    {
	    /// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<TReturn> body) : base(new Type[0], typeof(TReturn), body)
        {
        }
    }

	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, TReturn> body) : base(new Type[] { typeof(T1) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="T14"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Defines a global function by a lambda function.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="T14"></typeparam>
	/// <typeparam name="T15"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : LambdaGlobalFunction
    {
		/// <summary>
        /// Creates a global lambda function.
        /// </summary>
        public LambdaGlobalFunction(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> body) : base(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) }, typeof(TReturn), body)
        {
        }
    }
	
	/// <summary>
    /// Defines a global function by a native MethodInfo.
    /// </summary>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeGlobalFunction<TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }

		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="T14"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
		/// <summary>
    /// Defines a global function by MethodInfo.
    /// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	/// <typeparam name="T3"></typeparam>
	/// <typeparam name="T4"></typeparam>
	/// <typeparam name="T5"></typeparam>
	/// <typeparam name="T6"></typeparam>
	/// <typeparam name="T7"></typeparam>
	/// <typeparam name="T8"></typeparam>
	/// <typeparam name="T9"></typeparam>
	/// <typeparam name="T10"></typeparam>
	/// <typeparam name="T11"></typeparam>
	/// <typeparam name="T12"></typeparam>
	/// <typeparam name="T13"></typeparam>
	/// <typeparam name="T14"></typeparam>
	/// <typeparam name="T15"></typeparam>
	/// <typeparam name="TReturn"></typeparam>
    public class NativeGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : NativeGlobalFunction
    {
		/// <summary>
        /// Creates a global native function.
        /// </summary>
        public NativeGlobalFunction(MethodInfo info) : base(info)
        {
        }
    }
	
	/// <summary>
    /// Extensions for native global functions.
    /// </summary>
	public static class NativeGlobalFunctionExtensions
	{
		private static Dictionary<int, Type> classes = new Dictionary<int, Type>()
		{
					{0, typeof(NativeGlobalFunction<>)},
					{1, typeof(NativeGlobalFunction<,>)},
					{2, typeof(NativeGlobalFunction<, ,>)},
					{3, typeof(NativeGlobalFunction<, , ,>)},
					{4, typeof(NativeGlobalFunction<, , , ,>)},
					{5, typeof(NativeGlobalFunction<, , , , ,>)},
					{6, typeof(NativeGlobalFunction<, , , , , ,>)},
					{7, typeof(NativeGlobalFunction<, , , , , , ,>)},
					{8, typeof(NativeGlobalFunction<, , , , , , , ,>)},
					{9, typeof(NativeGlobalFunction<, , , , , , , , ,>)},
					{10, typeof(NativeGlobalFunction<, , , , , , , , , ,>)},
					{11, typeof(NativeGlobalFunction<, , , , , , , , , , ,>)},
					{12, typeof(NativeGlobalFunction<, , , , , , , , , , , ,>)},
					{13, typeof(NativeGlobalFunction<, , , , , , , , , , , , ,>)},
					{14, typeof(NativeGlobalFunction<, , , , , , , , , , , , , ,>)},
					{15, typeof(NativeGlobalFunction<, , , , , , , , , , , , , , ,>)},
			
		};
		/// <summary>
        /// Converts a MethodInfo into a global function.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
		public static IGlobalFunction CreateByMethodInfo(MethodInfo info)
		{
            var parameterTypes = info.GetParameters().Select(p => p.ParameterType).ToArray();
            var @class = classes[parameterTypes.Length];
            var genericClass = @class.MakeGenericType(parameterTypes.Concat(new[] { info.ReturnType.Unvoid() }).ToArray());
            return (IGlobalFunction)Activator.CreateInstance(genericClass, info);
		}
	}
}