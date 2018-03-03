using CQL.Contexts.Implementation;
using CQL.TypeSystem.Implementation;
using System;

namespace CQL.Contexts
{
    public interface IVariable<TAbstraction>
    {
        string Name { get; }
        TAbstraction Value { get; }
    }

    public static class VariableExtensions
    {
        public static IVariable<Type> ToValidationVariable(this IVariable<object> @this)
        {
            return new Variable<Type>(@this.Name, @this.Value.GetType());
        }
    }
}