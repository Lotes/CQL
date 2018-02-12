using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public class AmbigiousTypeException: Exception
    {
        public readonly Type GivenType;
        public readonly IEnumerable<IType> KnownTypes;
        public AmbigiousTypeException(Type type, IEnumerable<IType> knownTypes) : base("Multiple type choices are possible for the requested type.")
        {
            GivenType = type;
            KnownTypes = knownTypes.ToArray();
        }
    }
}
