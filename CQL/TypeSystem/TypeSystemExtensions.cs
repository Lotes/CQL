using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// Extensions for <see cref="ITypeSystem"/>.
    /// </summary>
    public static class TypeSystemExtensions
    {
        /// <summary>
        /// Applies a set of type casts to an expression. This will insert several cast expressions.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="expression"></param>
        /// <param name="context"></param>
        /// <param name="generateError"></param>
        /// <returns></returns>
        public static IExpression ApplyCast(this IEnumerable<CoercionRule> @this, IExpression expression, IValidationScope context, Func<Exception> generateError = null)
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

        /// <summary>
        /// Given to R-values, trys to unify both value's type by calling implicit type conversions.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <param name="generateError"></param>
        /// <returns></returns>
        public static Type AlignTypes(this IValidationScope @this, ref IExpression lhs, ref IExpression rhs, Func<Exception> generateError)
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
