using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.Tags
{
    /// <summary>
    /// Contains constants and helper functions.
    /// </summary>
    public static class TagFilters
    {
        public const string Uncategorized = "UNCATEGORIZED";
        public const string Any = "ANY";
        public const string Multiple = "MULTIPLE";
        public static readonly IEnumerable<string> Names = new[] 
        {
            Uncategorized,
            Any,
            Multiple
        };
    }
}
