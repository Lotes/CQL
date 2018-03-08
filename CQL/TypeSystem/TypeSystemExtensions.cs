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
        private static Func<IType, Type, IEnumerable<Type>, Type, MethodInfo, IdDelimiter, string, IMethod> AddMemberFunction;
        private static Func<IType, Type, IEnumerable<Type>, MethodInfo, IdDelimiter, string, IMethod> AddMemberAction;

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

            AddMemberFunction = (@this, sourceType, parameterTypes, returnType, methodInfo,
                delimiter, name) =>
            {
                var genericType = type.MakeGenericType(sourceType);
                var addMethodMethod = genericType.GetMethods().FirstOrDefault(m => m.Name == "AddFunction"
                    && m.GetGenericArguments().Length == 1 + parameterTypes.Count());
                if (addMethodMethod == null)
                    throw new InvalidOperationException("Could not find add method!");
                var genericAdd = addMethodMethod.MakeGenericMethod(parameterTypes.Concat(new[] { returnType }).ToArray());
                var param = Expression.Parameter(sourceType, "instance");
                var @params = parameterTypes.Select(pt => Expression.Parameter(pt)).ToArray();
                var lambda = Expression.Lambda(Expression.Call(param, methodInfo, @params), new[] { param }.Concat(@params).ToArray());
                var func = lambda.Compile();
                return (IMethod)genericAdd.Invoke(@this, new object[] { delimiter, name, func });
            };

            AddMemberAction = (@this, sourceType, parameterTypes, methodInfo,
                delimiter, name) =>
            {
                var genericType = type.MakeGenericType(sourceType);
                var addMethodMethod = genericType.GetMethods().FirstOrDefault(m => m.Name == "AddAction"
                    && m.GetGenericArguments().Length == parameterTypes.Count());
                if (addMethodMethod == null)
                    throw new InvalidOperationException("Could not find add method!");
                var genericAdd = parameterTypes.Any() 
                    ? addMethodMethod.MakeGenericMethod(parameterTypes.ToArray())
                    : addMethodMethod;
                var param = Expression.Parameter(sourceType, "instance");
                var @params = parameterTypes.Select(pt => Expression.Parameter(pt)).ToArray();
                var lambda = Expression.Lambda(Expression.Call(param, methodInfo, @params), new[] { param }.Concat(@params).ToArray());
                var func = lambda.Compile();
                return (IMethod)genericAdd.Invoke(@this, new object[] { delimiter, name, func });
            };
        }

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
                .Select(p => new { prop = p, attrs = p.GetCustomAttributes<CQLPropertyAttribute>().FirstOrDefault() })
                .Where(p => p.attrs != null)
                .ToArray();
            foreach (var property in properties)
                AddProperty(cqlType, type, property.prop.PropertyType, property.prop, property.attrs.Delimiter, property.attrs.Name);

            //MemberFunctions/Actions
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(m => new { method = m, attr = m.GetCustomAttributes<CQLMethodAttribute>().FirstOrDefault() })
                .Where(m => m.attr != null)
                .ToArray();
            foreach(var method in methods)
            {
                var @params = method.method.GetParameters().Select(p => p.ParameterType).ToArray();
                var @return = method.method.ReturnType;
                if (@return == typeof(void))
                    AddMemberAction(cqlType, type, @params, method.method, method.attr.Delimiter, method.attr.Name);
                else
                    AddMemberFunction(cqlType, type, @params, @return, method.method, method.attr.Delimiter, method.attr.Name);
            }
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
