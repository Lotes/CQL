using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Plus<T>(this IEnumerable<T> @this, params T[] added)
        {
            return @this.Concat(added);
        }
    }
}
