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
        //IProperty AddProperty<TProperty>(IdDelimiter delimiter, string name, Func<TType, TProperty> getter);
        private static Func<IType, Type, Type, PropertyInfo, IdDelimiter, string, IProperty> AddProperty;
        //IMethod AddFunction<T1, T2, T3, T4, T5, T6, TResult>(IdDelimiter delimiter, string name, Func<TType, T1, T2, T3, T4, T5, T6, TResult> func);
        //private static Func<IType, Type, IEnumerable<Type>, Type, MethodInfo, IdDelimiter, string, IMethod> AddMethod;

        static TypeSystemBuilderExtensions()
        {
            var type = typeof(IType<>);
            AddProperty = (@this, sourceType, propertyType, propertyInfo, 
                delimiter, name) =>
            {
                var genericType = type.MakeGenericType(sourceType);
                var addPropertyMethod = genericType.GetMethod("AddProperty");
                var genericAdd = addPropertyMethod.MakeGenericMethod(propertyType);
                var param = Expression.Parameter(sourceType, "instance");
                var lambda = Expression.Lambda(Expression.Property(param, propertyInfo.GetMethod), param);
                var func = lambda.Compile();
                return (IProperty)genericAdd.Invoke(@this, new object[] { delimiter, name, func });
            };
            /*AddMethod = (@this, sourceType, parameterTypes, returnType, methodInfo,
                delimiter, name) =>
            {
                var genericType = type.MakeGenericType(sourceType);
                var addMethodMethod = genericType.GetMethod()
                return null;
            };*/
        }

        private static void AddTypeScan(this ITypeSystemBuilder @this, Type type)
        {
            var attributes = type.GetCustomAttributes<CQLTypeAttribute>();
            if (attributes == null || !attributes.Any())
                return;
            var attribute = attributes.First();

            var addType = typeof(ITypeSystemBuilder).GetMethod("AddType").MakeGenericMethod(type);
            var cqlType = (IType)addType.Invoke(@this, new object[] { attribute.Name, attribute.Usage, TypeDefaultFlags.All });

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new { prop = p, attrs = p.GetCustomAttributes<CQLPropertyAttribute>().FirstOrDefault() })
                .Where(p => p.attrs != null)
                .ToArray();
            foreach (var property in properties)
                AddProperty(cqlType, type, property.prop.PropertyType, property.prop, property.attrs.Delimiter, property.attrs.Name);
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
