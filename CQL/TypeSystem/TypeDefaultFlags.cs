using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    [Flags]
    public enum TypeDefaultFlags
    {
        None = 0,
        Equals = 1,
        Comparable = 2,
        Numeric = 4,
        All = Equals | Comparable | Numeric 
    }
}
