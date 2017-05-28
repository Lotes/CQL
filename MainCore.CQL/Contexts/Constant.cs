using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts
{
    public class Constant: INameable
    {
        public string Name { get; private set; }
        public string Usage { get; private set; }
        public readonly Type FieldType;
        public readonly Func<object> Getter;
        public Constant(string name, string usage, Type fieldType, Func<object> getter)
        {
            Name = name;
            Usage = usage;
            FieldType = fieldType;
            Getter = getter;
        }
    }
}
