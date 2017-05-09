using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.TypeSystem
{
    public class QType
    {
        public readonly string Name;
        public readonly Type ActualType;

        public QType(string name, Type actualType)
        {
            Name = name;
            ActualType = actualType;
        }
    }
}
