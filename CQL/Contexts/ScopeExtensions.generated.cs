using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
	public static partial class ScopeExtensions
    {
        private class Closure<TGlobalFunction> : IGlobalFunctionClosure<TGlobalFunction>
            where TGlobalFunction : IGlobalFunction
        {
            public Closure(TGlobalFunction method)
            {
                Function = method;
            }
            public TGlobalFunction Function { get; private set; }
            public object Invoke(params object[] parameters)
            {
                return Function.Invoke(parameters);
            }
        }
		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IVariableDefinition DefineForeignGlobalFunction<TResult>(this EvaluationScope @this, string name, Func<TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<TResult>>(new LambdaGlobalFunction<TResult>(func)));
        }
		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, TResult>(this EvaluationScope @this, string name, Func<T1, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, TResult>>(new LambdaGlobalFunction<T1, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, TResult>(this EvaluationScope @this, string name, Func<T1, T2, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, TResult>>(new LambdaGlobalFunction<T1, T2, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, TResult>>(new LambdaGlobalFunction<T1, T2, T3, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="T7"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
        /// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="T7"></typeparam>
		/// <typeparam name="T8"></typeparam>
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func)));
        }

		/// <summary>
        /// Defines a global function using a lambda function.
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
		        /// <typeparam name="TResult"></typeparam>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="func"></param>
        /// <returns></returns>
		public static IVariable<object> DefineForeignGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func)));
        }

		    }
}