using System;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Marks an indexer property to be registered in the type and type system builder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CQLNativeMemberIndexerAttribute : Attribute
    {
    }
}
