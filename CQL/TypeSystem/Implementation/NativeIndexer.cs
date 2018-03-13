using System;
using System.Linq;
using System.Reflection;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// A native indexer is a PropertyInfo of the native type of the corressponding <see cref="IType{TType}"/>.
    /// </summary>
    public class NativeIndexer : IMemberIndexer
    {
        private PropertyInfo property;
        /// <summary>
        /// Creates a native indexer.
        /// </summary>
        /// <param name="property"></param>
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
        /// <summary>
        /// Indices types.
        /// </summary>
        public Type[] FormalParameters { get; private set; }
        /// <summary>
        /// Return type.
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// Evaluates the indexer property.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public object Get(object @this, params object[] indices)
        {
            return property.GetGetMethod().Invoke(@this, indices);
        }
    }
}
