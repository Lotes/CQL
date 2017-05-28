using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public static class Extensions
    {
        public static bool StructurallyEquals(this IEnumerable<ISyntaxTreeNode> @this, IEnumerable<ISyntaxTreeNode> other)
        {
            return
                ((@this != null) == (other!= null))
                && (@this == null || (@this.Count() == other.Count() 
                  && @this.Zip(other, (first, second) => first.StructurallyEquals(second))
                        .All(a => a)));
        }

        public static bool IfArrayTryGetElementType(this IExpression @this, out Type elementType)
        {
            if (@this is ArrayExpression)
            {
                elementType = ((ArrayExpression)@this).ElementType;
                return true;
            }
            else
                return @this.SemanticType.IfEnumerableTryGetElementType(out elementType);
        }
    }
}
