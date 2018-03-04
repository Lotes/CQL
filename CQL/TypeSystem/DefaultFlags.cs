using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    [Flags]
    public enum DefaultFlags
    {
        None = 0,
        HasBoolean = 1,
        HasWholeNumbers = 2,
        HasDecimalNumbers = 4,
        HasStrings = 8,
        All = HasBoolean | HasWholeNumbers | HasDecimalNumbers | HasStrings
    }
}
