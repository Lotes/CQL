using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts
{
    /// <summary>
    /// Extensions for scopes
    /// </summary>
    public static partial class ScopeExtensions
    {
        /// <summary>
        /// Global name normalization function.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NormalizeVariableName(string str)
        {
            return str.ToUpper();
        }

        /// <summary>
        /// Scans a type and its nested types for e.g. <see cref="CQLGlobalFunction"/> to extend the scope with global functions and variables.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        public static void AddFromScan(this IEvaluationScope @this, Type type)
        {
            var types = new[] { type }.Concat(type.GetNestedTypes());
            foreach (var tpe in types)
                @this.AddTypeScan(tpe);
        }

        /// <summary>
        /// Scans an assembly for e.g. <see cref="CQLGlobalFunction"/> to extend the scope with global functions and variables.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="assembly"></param>
        public static void AddFromScan(this IEvaluationScope @this, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
                @this.AddTypeScan(type);
        }

        /// <summary>
        /// Checks type for e.g. <see cref="CQLGlobalFunction"/> to extend the scope with global functions and variables.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="type"></param>
        public static void AddTypeScan(this IEvaluationScope @this, Type type)
        {
            var functions = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Select(f => new { func = f, attr = f.GetCustomAttributes<CQLGlobalFunction>().FirstOrDefault() })
                .Where(f => f.attr != null)
                .ToArray();
            foreach (var function in functions)
                @this.DefineNativeGlobalFunction(function.attr.Name, function.func);
        }

        private static Action<IEvaluationScope, Type, string, IGlobalFunction> addGlobalFunction;
        static ScopeExtensions()
        {
            addGlobalFunction = (scope, functionType, name, function) =>
            {
                var genericType = typeof(Closure<>).MakeGenericType(functionType);
                var closure = (IGlobalFunctionClosure)Activator.CreateInstance(genericType, function);
                scope.DefineVariable(name, closure);
            };
        }

        /// <summary>
        /// Defines a global function by its <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="name"></param>
        /// <param name="info"></param>
        public static void DefineNativeGlobalFunction(this IEvaluationScope @this, string name, MethodInfo info)
        {
            var function = NativeGlobalFunctionExtensions.CreateByMethodInfo(info);
            addGlobalFunction(@this, function.GetType(), name, function);
        }
    }
}
