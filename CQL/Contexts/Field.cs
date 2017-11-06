using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts
{
    public class Field: INameable
    {
        public string Name { get; private set; }
        public string Usage { get; private set; }
        public readonly Type HostType;
        public readonly Type FieldType;
        public readonly Func<object, object> Getter;
        public readonly Func<object, bool> IsNull;
        public Field(string name, string usage, Type hostType, Type fieldType, Func<object, object> getter, Func<object, bool> isNull)
        {
            Name = name;
            Usage = usage;
            HostType = hostType;
            FieldType = fieldType;
            Getter = getter;
            IsNull = isNull;
        }
    }
}
