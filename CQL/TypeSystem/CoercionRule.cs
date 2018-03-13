using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    /// <summary>
    /// This rule class defines the conversion of an original type to a destination (casting) type.
    /// The rule can be implicit or explicit. Implicit rules can be applied during validation process.
    /// </summary>
    public class CoercionRule
    {
        /// <summary>
        /// Implicit or explicit.
        /// </summary>
        public readonly CoercionKind Kind;
        /// <summary>
        /// Source type of conversion.
        /// </summary>
        public readonly Type OriginalType;
        /// <summary>
        /// Destination type of conversion.
        /// </summary>
        public readonly Type CastingType;
        /// <summary>
        /// The actual conversion method.
        /// </summary>
        public readonly Func<object, object> Cast;
        /// <summary>
        /// Creates a coercion rule
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="originalType"></param>
        /// <param name="castingType"></param>
        /// <param name="cast"></param>
        public CoercionRule(CoercionKind kind, Type originalType, Type castingType, Func<object, object> cast)
        {
            Kind = kind;
            OriginalType = originalType;
            CastingType = castingType;
            Cast = cast;
        }
    }
}
