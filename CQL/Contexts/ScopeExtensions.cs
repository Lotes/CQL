using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
	public static class ScopeExtensions
    {
        private class Closure<TGlobalFunction> : IFunctionClosure<TGlobalFunction>
            where TGlobalFunction : LambdaGlobalFunction
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

        public static readonly string ThisName = "this";
        public static IScope<Type> ToValidationScope(this IScope<object> @this)
        {
            if (@this == null)
                return null;
            var result = new ValidationScope(@this.TypeSystem, @this.Parent.ToValidationScope());
            foreach (var elem in @this)
                result.DefineVariable(elem.Name, elem.Value?.GetType() ?? typeof(object));
            return result;
        }
        public static bool TryGetThis<T>(this IScope<T> @this, out IVariable<T> variable)
        {
            return @this.TryGetVariable(ThisName, out variable);
        }
        public static IVariable<T> DefineThis<T>(this IScope<T> @this, T value)
        {
            return @this.DefineVariable(ThisName, value);
        }


				
        public static IVariable<object> DefineFunction<TResult>(this EvaluationScope @this, string name, Func<TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<TResult>>(new LambdaGlobalFunction<TResult>(func)));
        }
		        
		public static IVariable<object> DefineFunction<T1, TResult>(this EvaluationScope @this, string name, Func<T1, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, TResult>>(new LambdaGlobalFunction<T1, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, TResult>(this EvaluationScope @this, string name, Func<T1, T2, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, TResult>>(new LambdaGlobalFunction<T1, T2, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, TResult>>(new LambdaGlobalFunction<T1, T2, T3, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(func)));
        }

		        
		public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>(new LambdaGlobalFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(func)));
        }

		    }
}