using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public static class TypeSystemExtensions
    {
        public static IExpression ApplyCast(this IEnumerable<CoercionRule> @this, IExpression expression, IScope<Type> context, Func<Exception> generateError = null)
        {
            if (!@this.Any())
            {
                if(generateError != null) throw generateError();
                return null;
            }
            var current = expression;
            foreach (var rule in @this)
                current = new CastExpression(rule, current);
            return current;
        }

        public static Type AlignTypes(this IScope<Type> @this, ref IExpression lhs, ref IExpression rhs, Func<Exception> generateError)
        {
            var chain = @this.TypeSystem.GetImplicitlyCastChain(lhs.SemanticType, rhs.SemanticType);
            var newLeft = chain.ApplyCast(lhs, @this);
            if (newLeft != null)
            {
                lhs = newLeft;
                return lhs.SemanticType;
            }
            else
            {
                chain = @this.TypeSystem.GetImplicitlyCastChain(rhs.SemanticType, lhs.SemanticType);
                var newRight = chain.ApplyCast(rhs, @this);
                if (newRight != null)
                {
                    rhs = newRight;
                    return rhs.SemanticType;
                }
                else
                    throw generateError();
            }
        }
    }

    public static class TypeSystemBuilderExtensions
    {
        private static void AddTypeScan(this ITypeSystemBuilder @this, Type type)
        {
            var attributes = type.GetCustomAttributes<CQLTypeAttribute>();
            if (attributes == null || !attributes.Any())
                return;
            var attribute = attributes.First();

            var addType = typeof(ITypeSystemBuilder).GetMethod("AddType").MakeGenericMethod(type);
            var cqlType = (IType)addType.Invoke(@this, new object[] { attribute.Name, attribute.Usage, TypeDefaultFlags.All });

            //Properties
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new { prop = p, attrs = p.GetCustomAttributes<CQLMemberNativePropertyAttribute>().FirstOrDefault() })
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

        public static Type Unvoid(this Type @this)
        {
            return @this.FullName == "System.Void" ? typeof(Void) : @this;
        }

        public static void AddFromScan(this ITypeSystemBuilder @this, Type type)
        {
            var types = new[] { type}.Concat(type.GetNestedTypes());
            foreach(var tpe in types)
                @this.AddTypeScan(tpe);
        }

        public static void AddFromScan(this ITypeSystemBuilder @this, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
                @this.AddTypeScan(type);
        }
    }
}
