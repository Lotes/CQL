using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public interface IType: INameable
    {
        Type CSharpType { get; }
        void AddMethod(MethodInfo info, string name);
        void AddProperty(PropertyInfo info, string name);
    }
}
