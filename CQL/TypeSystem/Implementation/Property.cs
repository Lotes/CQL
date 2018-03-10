using System;
using CQL.SyntaxTree;
using System.Reflection;

namespace CQL.TypeSystem.Implementation
{
    public class NativeProperty : IProperty
    {
        private PropertyInfo property;
        public NativeProperty(IdDelimiter delimiter, string name, PropertyInfo property)
        {
            this.property = property;
            this.Delimiter = delimiter;
            this.Name = name;
            this.ReturnType = property.PropertyType;
        }

        public IdDelimiter Delimiter { get; private set; }
        public string Name { get; private set; }
        public Type ReturnType { get; private set; }

        public object Get(object @this)
        {
            return property.GetGetMethod().Invoke(@this, new object[0]);
        }
    }

    public class ForeignProperty : IProperty
    {
        private Func<object, object> getter;

        public ForeignProperty(IdDelimiter delimiter, string name, Type returnType, Func<object, object> getter)
        {
            this.Delimiter = delimiter;
            this.Name = name;
            this.ReturnType = returnType;
            this.getter = getter;
        }

        public IdDelimiter Delimiter { get; private set; }
        public string Name { get; private set; }
        public Type ReturnType { get; private set; }

        public object Get(object @this)
        {
            return getter.DynamicInvoke(@this);
        }
    }
}