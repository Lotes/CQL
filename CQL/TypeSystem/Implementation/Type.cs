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
        private Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
        private Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();

        public Type(string name, string usage, System.Type cSharpType)
        {
            Name = name;
            Usage = usage;
            CSharpType = cSharpType;
        }

        public string Name { get; private set; }
        public string Usage { get; private set; }
        public System.Type CSharpType { get; private set; }

        public void AddMethod(MethodInfo info, string name)
        {
            
        }

        public void AddProperty(PropertyInfo info, string name)
        {
            
        }
    }
}
