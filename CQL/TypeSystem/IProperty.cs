using System;

namespace CQL.TypeSystem
{
    public interface IProperty
    {
        string Name { get; }
        Type ReturnType { get; }
        object Get(object @this);
    }
}