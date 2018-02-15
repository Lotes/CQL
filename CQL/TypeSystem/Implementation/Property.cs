using System;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    internal class Property : IProperty
    {
        private IdDelimiter delimiter;
        private Func<object, object> getter;
        private string name;
        private Action<object, object> setter;

        public Property(IdDelimiter delimiter, string name, Func<object, object> getter, Action<object, object> setter)
        {
            this.delimiter = delimiter;
            this.name = name;
            this.getter = getter;
            this.setter = setter;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public object Get(object @this)
        {
            return getter(@this);
        }

        public void Set(object @this, object value)
        {
            setter.Invoke(@this, value);
        }
    }
}