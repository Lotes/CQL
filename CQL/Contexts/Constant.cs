using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts
{
    public class Constant: INameable
    {
        public string Name { get; private set; }
        public string Usage { get; private set; }
        public readonly Type FieldType;
        public readonly Type HostType;
        public readonly Func<object, object> Getter;
        public Constant(string name, string usage, Type hostType, Type fieldType, Func<object, object> getter)
        {
            Name = name;
            Usage = usage;
            HostType = hostType;
            FieldType = fieldType;
            Getter = getter;
        }
    }
}
