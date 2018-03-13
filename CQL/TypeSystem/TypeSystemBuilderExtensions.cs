using System;
using System.Linq;
using System.Reflection;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Extensions for <see cref="ITypeSystemBuilder"/>.
    /// </summary>
    public static class TypeSystemBuilderExtensions
    {
        /// <summary>
        /// Scans a SINGLE type for e.g. the <see cref="CQLTypeAttribute"/> and extends the builder with these types including 
        /// properties, indexers and methods.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        public static void AddTypeScan(this ITypeSystemBuilder @this, Type type)
        {
            var attributes = type.GetCustomAttributes<CQLTypeAttribute>();
            if (attributes == null || !attributes.Any())
                return;
            var attribute = attributes.First();

            var addType = typeof(ITypeSystemBuilder).GetMethod("AddType").MakeGenericMethod(type);
            var cqlType = (IType)addType.Invoke(@this, new object[] { attribute.Name, attribute.Usage, TypeDefaultFlags.All });

            //Properties
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new { prop = p, attrs = p.GetCustomAttributes<CQLNativeMemberPropertyAttribute>().FirstOrDefault() })
                .Where(p => p.attrs != null)
                .ToArray();
            foreach (var property in properties)
                cqlType.AddNativeProperty(property.attrs.Delimiter, property.attrs.Name, property.prop);

            //MemberFunctions/Actions
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(m => new { method = m, attr = m.GetCustomAttributes<CQLNativeMemberFunctionAttribute>().FirstOrDefault() })
                .Where(m => m.attr != null)
                .ToArray();
            foreach(var method in methods)
                cqlType.AddNativeFunction(method.attr.Delimiter, method.attr.Name, method.method);

            //Indexers
            var indexers = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name == "Item")
                .Select(p => new { prop = p, attrs = p.GetCustomAttributes<CQLNativeMemberIndexerAttribute>().FirstOrDefault() })
                .Where(p => p.attrs != null)
                .ToArray();
            foreach (var indexer in indexers)
                cqlType.AddNativeIndexer(indexer.prop);
        }

        /// <summary>
        /// Converts the type <see cref="System.Void"/> to <see cref="Void"/>, because C# does not allow <see cref="Func{T, TResult}"/> using the original type.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static Type Unvoid(this Type @this)
        {
            return @this.FullName == "System.Void" ? typeof(Void) : @this;
        }

        /// <summary>
        /// Scans type including its nested type for CQL types that could be registrated in this builder.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        public static void AddFromScan(this ITypeSystemBuilder @this, Type type)
        {
            var types = new[] { type}.Concat(type.GetNestedTypes());
            foreach(var tpe in types)
                @this.AddTypeScan(tpe);
        }

        /// <summary>
        /// Scans a assembly for all types with <see cref="CQLTypeAttribute"/> and registers these types as CQL types in the builder.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="assembly"></param>
        public static void AddFromScan(this ITypeSystemBuilder @this, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
                @this.AddTypeScan(type);
        }
    }
}
