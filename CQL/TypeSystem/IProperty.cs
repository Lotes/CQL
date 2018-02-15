using System;

namespace CQL.TypeSystem
{
    public interface IProperty: ISymbol
    {
        Type ReturnType { get; }
        object Get(object @this);
        void Set(object @this, object value);
    }
}