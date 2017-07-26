using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL
{
    public static class HashExtensions
    {
        public static int GetCommonHashCode(this IEnumerable<object> @this)
        {
            return @this.Select(obj => obj.GetHashCode())
                .Aggregate(0, (lhs, rhs) => unchecked(17 * lhs + rhs));
        }
    }
}
