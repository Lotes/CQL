using CQL.TypeSystem.Implementation;

namespace CQL.Contexts
{
    /// <summary>
    /// An abstract variable.
    /// </summary>
    /// <typeparam name="TAbstraction"><see cref="System.Type"/> or <see cref="System.Object"/></typeparam>
    public interface IVariable<TAbstraction>
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Abstract value.
        /// </summary>
        TAbstraction Value { get; }
    }
}