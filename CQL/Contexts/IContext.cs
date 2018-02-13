using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts
{
    public interface IContext<TAbstraction>
    {
        ITypeSystem TypeSystem { get; }
        void PushScope();
        void PopScope();
        IScope<TAbstraction> Scope { get; }
        Stack<TAbstraction> Stack { get; }
    }

    public static class ContextExtensions
    {
        public static IContext<Type> ToValidationContext(this IContext<object> @this)
        {
            var result = new Context<Type>(@this.TypeSystem);
            foreach(var elem in @this.Stack.Reverse().Select(t => t.GetType()))
                result.Stack.Push(elem);
            @this.Scope
            return result;
        }
    }
}
