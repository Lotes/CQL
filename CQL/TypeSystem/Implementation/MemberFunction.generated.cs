using System.Reflection;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{	
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, TReturn> body) : base(typeof(TThis), new Type[0], typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, TReturn> body) : base(typeof(TThis), new[] { typeof(T1) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping foreign member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class ForeignMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : ForeignMemberFunction
    {
		/// <summary>
        /// Creates a foreign member function.
        /// </summary>
        /// <param name="body"></param>
        public ForeignMemberFunction(Func<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> body) : base(typeof(TThis), new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15) }, typeof(TReturn), body)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis,  TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Types wrapping native member function.
    /// </summary>
    /// <typeparam name="TThis"></typeparam>
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
	public class NativeMemberFunction<TThis, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : NativeMemberFunction
    {
        /// <summary>
        /// Creates a native member function.
        /// </summary>
        /// <param name="info"></param>
        public NativeMemberFunction(MethodInfo info) : base(typeof(TThis), info)
        {
        }
    }
	/// <summary>
    /// Extensions for native member functions.
    /// </summary>
	public static class NativeMemberFunctionExtensions
	{
		private static Dictionary<int, Type> classes = new Dictionary<int, Type>()
		{
					{0, typeof(NativeMemberFunction<,>)},
					{1, typeof(NativeMemberFunction<,,>)},
					{2, typeof(NativeMemberFunction<,, ,>)},
					{3, typeof(NativeMemberFunction<,, , ,>)},
					{4, typeof(NativeMemberFunction<,, , , ,>)},
					{5, typeof(NativeMemberFunction<,, , , , ,>)},
					{6, typeof(NativeMemberFunction<,, , , , , ,>)},
					{7, typeof(NativeMemberFunction<,, , , , , , ,>)},
					{8, typeof(NativeMemberFunction<,, , , , , , , ,>)},
					{9, typeof(NativeMemberFunction<,, , , , , , , , ,>)},
					{10, typeof(NativeMemberFunction<,, , , , , , , , , ,>)},
					{11, typeof(NativeMemberFunction<,, , , , , , , , , , ,>)},
					{12, typeof(NativeMemberFunction<,, , , , , , , , , , , ,>)},
					{13, typeof(NativeMemberFunction<,, , , , , , , , , , , , ,>)},
					{14, typeof(NativeMemberFunction<,, , , , , , , , , , , , , ,>)},
					{15, typeof(NativeMemberFunction<,, , , , , , , , , , , , , , ,>)},
			
		};
		/// <summary>
        /// Converts a MethodInfo into a native member function.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="info"></param>
        /// <returns></returns>
		public static IMemberFunction CreateByMethodInfo(Type @this, MethodInfo info)
		{
            var parameterTypes = info.GetParameters().Select(p => p.ParameterType).ToArray();
            var @class = classes[parameterTypes.Length];
            var genericClass = @class.MakeGenericType(new[] { @this }.Concat(parameterTypes).Concat(new[] { info.ReturnType.Unvoid() }).ToArray());
            return (IMemberFunction)Activator.CreateInstance(genericClass, info);
		}
	}
}