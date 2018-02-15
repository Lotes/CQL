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
        private Delegate setter;
        public Indexer(Type[] formalParameters, Type returnType, Delegate getter, Delegate setter)
        {
            FormalParameters = formalParameters;
            ReturnType = returnType;
            this.getter = getter;
            this.setter = setter;
        }
        public Type[] FormalParameters { get; private set; }
        public Type ReturnType { get; private set; }
        public object Get(object @this, params object[] indices)
        {
            return getter.Method.Invoke(null, new[] { @this }.Concat(indices).ToArray());
        }

        public void Set(object @this, object[] indices, object value)
        {
            setter.Method.Invoke(null, new[] { @this }.Concat(indices).Concat(new[] { value }).ToArray());
        }
    }
}
