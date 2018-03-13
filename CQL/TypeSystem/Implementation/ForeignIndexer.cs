using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    /// <summary>
    /// A foreign indexer is a lambda function used as index property.
    /// </summary>
    public class ForeignIndexer : IMemberIndexer
    {
        private Delegate getter;
        /// <summary>
        /// Creates a foreign indexer.
        /// </summary>
        /// <param name="formalParameters"></param>
        /// <param name="returnType"></param>
        /// <param name="getter"></param>
        public ForeignIndexer(Type[] formalParameters, Type returnType, Delegate getter)
        {
            FormalParameters = formalParameters;
            ReturnType = returnType;
            this.getter = getter;
        }
        /// <summary>
        /// Types of the indices.
        /// </summary>
        public Type[] FormalParameters { get; private set; }
        /// <summary>
        /// Return type.
        /// </summary>
        public Type ReturnType { get; private set; }
        /// <summary>
        /// Evaluates the foreign lambda function on the THIS object with a set of indices.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public object Get(object @this, params object[] indices)
        {
            return getter.DynamicInvoke(new[] { @this }.Concat(indices).ToArray());
        }
    }
}
