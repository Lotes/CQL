namespace CQL.TypeSystem
{
    /// <summary>
    /// Represenst an indexer for a type.
    /// </summary>
    public interface IMemberIndexer
    {
        /// <summary>
        /// Return type of the indexer.
        /// </summary>
        System.Type ReturnType { get; }
        /// <summary>
        /// Types of all indices for the access.
        /// </summary>
        System.Type[] FormalParameters { get; }
        /// <summary>
        /// Access via indexer by passing concrete parameters and a THIS object.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        object Get(object @this, params object[] indices);
    }
}