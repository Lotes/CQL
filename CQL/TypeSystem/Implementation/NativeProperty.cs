using System;
using CQL.SyntaxTree;
using System.Reflection;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// A native property is a property of an <see cref="IType{TType}"/> by accessing a real 
    /// <see cref="PropertyInfo"/> of the type TType.
    /// </summary>
    public class NativeProperty : IProperty
    {
        private PropertyInfo property;
        /// <summary>
        /// Creates a native property.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="property"></param>
        public NativeProperty(string name, PropertyInfo property)
        {
            this.property = property;
            this.Name = name;
            this.ReturnType = property.PropertyType;
        }
        /// <summary>
        /// Name of the property.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Return type.
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// Returns the property value of the THIS parameter. 
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public object Get(object @this)
        {
            return property.GetGetMethod().Invoke(@this, new object[0]);
        }
    }
}