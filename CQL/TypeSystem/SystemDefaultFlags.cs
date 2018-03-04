using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    [Flags]
    public enum SystemDefaultFlags
    {
        None = 0,
        HasBoolean = 1,
        HasIntegers = 2,
        HasDoubles = 4,
        HasStrings = 8,
        All = HasBoolean | HasIntegers | HasDoubles | HasStrings
    }
}
