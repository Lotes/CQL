using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts.Implementation
{
    public class FieldSet : IFieldSet
    {
        private Dictionary<string, Field> fields = new Dictionary<string, Field>();

        public void Add<THost, TField>(string name, Func<THost, TField> getter)
        {
            if (Get(name) != null)
                throw new InvalidOperationException("Such a field does already exist!");
            fields[name.ToLower()] = new Field(name, typeof(THost), typeof(TField), host => getter((THost)host));
        }

        public Field Get(string name)
        {
            name = name.ToLower();
            if (!fields.ContainsKey(name))
                return null;
            return fields[name];
        }
    }
}
