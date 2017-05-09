using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public class Field
    {
        public readonly string Name;
        public readonly Type HostType;
        public readonly Type FieldType;
        public readonly Func<object, object> Getter;
        public Field(string name, Type hostType, Type fieldType, Func<object, object> getter)
        {
            Name = name;
            HostType = hostType;
            FieldType = fieldType;
            Getter = getter;
        }
    }
}
