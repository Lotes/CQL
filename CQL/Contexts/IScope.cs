using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
    public interface IScope<TAbstraction>: IEnumerable<IVariable<TAbstraction>>
    {
        ITypeSystem TypeSystem { get; }
        bool TryGetVariable(string name, out IVariable<TAbstraction> variable);
        IVariable<TAbstraction> DefineVariable(string name, TAbstraction value);
        IScope<TAbstraction> Parent { get; }
    }

    public static class ScopeExtensions
    {
        private class Closure<TFunction> : IFunctionClosure<TFunction>
            where TFunction : Function
        {
            public Closure(TFunction method)
            {
                Function = method;
            }
            public TFunction Function { get; private set; }
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
            return @this.DefineVariable(name, new Closure<Function<TResult>>(new Function<TResult>(func)));
        }
        public static IVariable<object> DefineFunction<T1, TResult>(this EvaluationScope @this, string name, Func<T1, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1>>(new Function<TResult, T1>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, TResult>(this EvaluationScope @this, string name, Func<T1, T2, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2>>(new Function<TResult, T1, T2>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, T3, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2, T3>>(new Function<TResult, T1, T2, T3>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, T3, T4, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2, T3, T4>>(new Function<TResult, T1, T2, T3, T4>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2, T3, T4, T5>>(new Function<TResult, T1, T2, T3, T4, T5>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2, T3, T4, T5, T6>>(new Function<TResult, T1, T2, T3, T4, T5, T6>(func)));
        }
        public static IVariable<object> DefineFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(this EvaluationScope @this, string name, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            return @this.DefineVariable(name, new Closure<Function<TResult, T1, T2, T3, T4, T5, T6, T7>>(new Function<TResult, T1, T2, T3, T4, T5, T6, T7>(func)));
        }
    }
}
