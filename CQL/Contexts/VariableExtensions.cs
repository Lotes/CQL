using CQL.Contexts.Implementation;
using System;

namespace CQL.Contexts
{
    /// <summary>
    /// Extensions for variables.
    /// </summary>
    public static class VariableExtensions
    {
        /// <summary>
        /// Converts a evaluation into a validation variable.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IVariableDeclaration ToValidationVariable(this IVariableDefinition @this)
        {
            return new VariableDeclaration(@this.Name, @this.Value.GetType());
        }
    }
}