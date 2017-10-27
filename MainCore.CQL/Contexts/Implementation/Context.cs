using MainCore.CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts.Implementation
{
    public class Context : IContext
    {
        private Dictionary<string, INameable> @namespace;
        public Context(ITypeSystem typeSystem, Dictionary<string, INameable> @namespace)
        {
            TypeSystem = typeSystem;
            this.@namespace = @namespace;
        }

        public IEnumerable<Constant> Constants { get { return @namespace.Values.OfType<Constant>(); } }
        public IEnumerable<Field> Fields { get { return @namespace.Values.OfType<Field>(); } }
        public IEnumerable<AbstractFunction> Functions { get { return @namespace.Values.OfType<AbstractFunction>(); } }

        public ITypeSystem TypeSystem { get; private set; }

        public INameable Get(string name)
        {
            INameable result;
            if (@namespace.TryGetValue(name.ToLower(), out result))
                return result;
            return null;
        }

        public IEnumerable<INameable> GetByPrefix(string prefix)
        {
            prefix = prefix.ToLower();
            var types = TypeSystem.GetTypesByPrefix(prefix);
            return @namespace.Where(kv => kv.Key.StartsWith(prefix)).Select(kv => kv.Value).Concat(types).ToArray();
        }
    }
}
