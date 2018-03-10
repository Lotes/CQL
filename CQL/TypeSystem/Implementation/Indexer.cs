using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class NativeIndexer : IMemberIndexer
    {
        private PropertyInfo property;
        public NativeIndexer(PropertyInfo property)
        {
            this.property = property;
            if (property.Name != "Item")
                throw new InvalidOperationException("This property is not an index accessor!");
            FormalParameters = property.GetIndexParameters().Select(p => p.ParameterType).ToArray();
            if(!FormalParameters.Any())
                throw new InvalidOperationException("This index accessor has no parameters!");
            ReturnType = property.PropertyType;
        }

        public Type[] FormalParameters { get; private set; }
        public Type ReturnType { get; private set; }
        public object Get(object @this, params object[] indices)
        {
            return property.GetGetMethod().Invoke(@this, indices);
        }
    }

    public class ForeignIndexer : IMemberIndexer
    {
        private Delegate getter;
        public ForeignIndexer(Type[] formalParameters, Type returnType, Delegate getter)
        {
            FormalParameters = formalParameters;
            ReturnType = returnType;
            this.getter = getter;
        }
        public Type[] FormalParameters { get; private set; }
        public Type ReturnType { get; private set; }
        public object Get(object @this, params object[] indices)
        {
            return getter.DynamicInvoke(new[] { @this }.Concat(indices).ToArray());
        }
    }
}
