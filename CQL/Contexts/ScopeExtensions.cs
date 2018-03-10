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
    public static partial class ScopeExtensions
    {
        public static void AddFromScan(this EvaluationScope @this, Type type)
        {
            var types = new[] { type }.Concat(type.GetNestedTypes());
            foreach (var tpe in types)
                @this.AddTypeScan(tpe);
        }

        public static void AddFromScan(this EvaluationScope @this, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
                @this.AddTypeScan(type);
        }

        public static void AddTypeScan(this EvaluationScope @this, Type type)
        {
            var functions = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Select(f => new { func = f, attr = f.GetCustomAttributes<CQLGlobalFunction>().FirstOrDefault() })
                .Where(f => f.attr != null)
                .ToArray();
            foreach (var function in functions)
                @this.DefineNativeGlobalFunction(function.attr.Name, function.func);
        }

        private static Action<EvaluationScope, Type, string, IGlobalFunction> addGlobalFunction;
        static ScopeExtensions()
        {
            addGlobalFunction = (scope, functionType, name, function) =>
            {
                var genericType = typeof(Closure<>).MakeGenericType(functionType);
                var closure = (IGlobalFunctionClosure)Activator.CreateInstance(genericType, function);
                scope.DefineVariable(name, closure);
            };
        }

        public static void DefineNativeGlobalFunction(this EvaluationScope @this, string name, MethodInfo info)
        {
            var function = NativeGlobalFunctionExtensions.CreateByMethodInfo(info);
            addGlobalFunction(@this, function.GetType(), name, function);
        }
    }
}
