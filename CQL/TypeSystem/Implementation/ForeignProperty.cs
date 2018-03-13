using System;
using CQL.SyntaxTree;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// A foreign property is a lambda function extracting information out of a THIS object.
    /// </summary>
    public class ForeignProperty : IProperty
    {
        private Func<object, object> getter;

        /// <summary>
        /// Creates a property using a lambda.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="returnType"></param>
        /// <param name="getter"></param>
        public ForeignProperty(IdDelimiter delimiter, string name, Type returnType, Func<object, object> getter)
        {
            this.Delimiter = delimiter;
            this.Name = name;
            this.ReturnType = returnType;
            this.getter = getter;
        }
        /// <summary>
        /// Delimiter of the property.
        /// </summary>
        public IdDelimiter Delimiter { get; private set; }
        /// <summary>
        /// Name of the proeprty.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Return type of this property.
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// Extracts the property value out of the THIS object.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public object Get(object @this)
        {
            return getter.DynamicInvoke(@this);
        }
    }
}