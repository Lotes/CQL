using CQL.Contexts.Implementation;
using System;

namespace CQL.Contexts
{
    public static class VariableExtensions
    {
        public static IVariable<Type> ToValidationVariable(this IVariable<object> @this)
        {
            return new Variable<Type>(@this.Name, @this.Value.GetType());
        }
    }
}