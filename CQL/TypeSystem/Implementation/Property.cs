using System;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    internal class Property : IProperty
    {
        private IdDelimiter delimiter;
        private Func<object, object> getter;
        private string name;

        public Property(IdDelimiter delimiter, string name, Type returnType, Func<object, object> getter)
        {
            this.delimiter = delimiter;
            this.name = name;
            this.getter = getter;
            ReturnType = returnType;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Type ReturnType { get; private set; }

        public object Get(object @this)
        {
            return getter(@this);
        }
    }
}