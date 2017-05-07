using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.Tags
{
    /// <summary>
    /// Special category members.
    /// </summary>
    public sealed class Tags
    {
        public static readonly Tag Extern = new Tag("", "EXTERN");
        public static readonly Tag FuSi = new Tag("", "FUSI");
        public static readonly Tag Generated = new Tag("", "GEN");
        public static readonly Tag Test = new Tag("", "TEST");
    }
}
