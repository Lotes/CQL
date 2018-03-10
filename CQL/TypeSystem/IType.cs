using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IType
    {
        Type CSharpType { get; }
        IProperty GetByName(IdDelimiter delimiter, string name);
        /// <summary>
        /// Null if not defined
        /// </summary>
        /// <returns></returns>
        IMemberIndexer Indexer { get; }
        IEnumerable<IProperty> Members { get; }

        IMemberFunction AddNativeFunction(IdDelimiter delimiter, string name, MethodInfo methodInfo);
        IProperty AddNativeProperty(IdDelimiter delimiter, string name, PropertyInfo propertyInfo);
        IMemberIndexer AddNativeIndexer(PropertyInfo propertyInfo);
    }

    public partial interface IType<TType>: IType
    {        
        IProperty AddForeignProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter);
    }
}
