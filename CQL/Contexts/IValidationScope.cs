using System;

namespace CQL.Contexts
{
    /// <summary>
    /// A validation scope is a dictionary of variables exposing only their type.
    /// The value is not important during validation process.
    /// </summary>
    public interface IValidationScope: IScope<Type, IValidationScope, IVariableDeclaration>
    {

    }
}
