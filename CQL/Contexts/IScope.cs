using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
    public interface IScope<TAbstraction>: IEnumerable<IVariable<TAbstraction>>
    {
        bool TryGetVariable(string name, out IVariable<TAbstraction> variable);
        IVariable<TAbstraction> DefineVariable(string name, TAbstraction value);
        IScope<TAbstraction> Parent { get; }
    }

    public static class ScopeExtensions
    {
        private static readonly string ThisName = "this";
        public static IScope<Type> ToValidationScope(this IScope<object> @this)
        {
            if (@this == null)
                return null;
            var result = new Scope<Type>(@this.Parent.ToValidationScope());
            foreach (var elem in @this)
                result.DefineVariable(elem.Name, elem.Value.GetType());
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
    }
}
