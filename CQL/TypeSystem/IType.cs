using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// A non-generic type registered in a type system.
    /// </summary>
    public interface IType
    {
        /// <summary>
        /// The CSharp type.
        /// </summary>
        Type NativeType { get; }
        /// <summary>
        /// Return a property by name.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        IProperty GetByName(IdDelimiter delimiter, string name);
        /// <summary>
        /// Is null when not defined.
        /// </summary>
        /// <returns></returns>
        IMemberIndexer Indexer { get; }
        /// <summary>
        /// Returns all registered members (properties and functions).
        /// </summary>
        IEnumerable<IProperty> Members { get; }
        /// <summary>
        /// Adds a native member function by its <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        IMemberFunction AddNativeFunction(IdDelimiter delimiter, string name, MethodInfo methodInfo);
        /// <summary>
        /// Adds a native member property by its <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        IProperty AddNativeProperty(IdDelimiter delimiter, string name, PropertyInfo propertyInfo);
        /// <summary>
        /// Adds a native indexer by its <see cref="PropertyInfo"/>
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        IMemberIndexer AddNativeIndexer(PropertyInfo propertyInfo);
    }

    public partial interface IType<TType>: IType
    { 
        /// <summary>
        /// Adds a foreign (lambda) property.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="delimiter"></param>
        /// <param name="name"></param>
        /// <param name="getter"></param>
        /// <returns></returns>
        IProperty AddForeignProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter);
    }
}
