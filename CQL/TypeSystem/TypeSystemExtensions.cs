using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
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

        public static Type AlignTypes(this IContext @this, ref IExpression lhs, ref IExpression rhs, Func<Exception> generateError)
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
}
