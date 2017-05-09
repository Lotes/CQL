using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public class CoercionRule
    {
        public readonly CoercionKind Kind;
        public readonly Type OriginalType;
        public readonly Type CastingType;
        public readonly Func<object, object> Cast;
        public CoercionRule(CoercionKind kind, Type originalType, Type castingType, Func<object, object> cast)
        {
            Kind = kind;
            OriginalType = originalType;
            CastingType = castingType;
            Cast = cast;
        }
    }
}
