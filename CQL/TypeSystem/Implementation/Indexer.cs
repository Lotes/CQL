using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class Indexer : IIndexer
    {
        private Delegate getter;
        public Indexer(Type[] formalParameters, Type returnType, Delegate getter)
        {
            FormalParameters = formalParameters;
            ReturnType = returnType;
            this.getter = getter;
        }
        public Type[] FormalParameters { get; private set; }
        public Type ReturnType { get; private set; }
        public object Get(object @this, params object[] indices)
        {
            return getter.Method.Invoke(null, new[] { @this }.Concat(indices).ToArray());
        }
    }
}
