using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public static class TypeSystemExtensions
    {
        public static IExpression ApplyCast(this IEnumerable<CoercionRule> @this, IExpression expression, IContext context, Func<Exception> generateError = null)
        {
            if (!@this.Any())
            {
                if(generateError != null) throw generateError();
                return null;
            }
            var current = expression;
            foreach (var rule in @this)
                current = new CastExpression(rule, current, context);
            return current;
        }
    }
}
