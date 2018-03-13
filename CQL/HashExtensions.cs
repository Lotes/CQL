using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL
{
    /// <summary>
    /// Extensions for hashing.
    /// </summary>
    public static class HashExtensions
    {
        /// <summary>
        /// Given a set of objects, computes a combined hash value. Order matters!
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static int GetCommonHashCode(this IEnumerable<object> @this)
        {
            return @this.Select(obj => obj.GetHashCode())
                .Aggregate(0, (lhs, rhs) => unchecked(17 * lhs + rhs));
        }
    }
}
