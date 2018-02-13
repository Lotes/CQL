using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class Type : IType
    {
        public Type(string name, string usage, System.Type cSharpType)
        {
            Name = name;
            Usage = usage;
            CSharpType = cSharpType;
        }

        public string Name { get; private set; }
        public string Usage { get; private set; }
        public System.Type CSharpType { get; private set; }
    }
}
