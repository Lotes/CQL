using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// Extension for the syntax tree.
    /// </summary>
    public static class SyntaxTreeExtensions
    {
        /// <summary>
        /// Check whether semantic type was already set
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool WasValidated(this IExpression @this) { return @this.SemanticType != null; }

        /// <summary>
        /// Deep equals sets of syntax trees.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool StructurallyEquals(this IEnumerable<ISyntaxTreeNode> @this, IEnumerable<ISyntaxTreeNode> other)
        {
            return
                ((@this != null) == (other != null))
                && (@this == null || (@this.Count() == other.Count()
                  && @this.Zip(other, (first, second) => first.StructurallyEquals(second))
                        .All(a => a)));
        }

        /// <summary>
        /// Get the element type if the expression is an array expression.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static bool IfArrayTryGetElementType(this IExpression @this, out Type elementType)
        {
            if (@this is ArrayExpression)
            {
                elementType = ((ArrayExpression)@this).SemanticType.GetElementType();
                return true;
            }
            else
                return @this.SemanticType.IfEnumerableTryGetElementType(out elementType);
        }
    }
}
