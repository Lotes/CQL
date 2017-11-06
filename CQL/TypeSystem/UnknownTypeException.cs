using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public class UnknownTypeException: Exception
    {
        public readonly Type KnownType;
        public UnknownTypeException(Type type) : base("This type is unknown to the given type system!")
        {
            KnownType = type;
        }
    }
}
