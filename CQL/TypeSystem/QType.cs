using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem
{
    public class QType: INameable
    {
        public readonly Type ActualType;

        public QType(string name, string usage, Type actualType)
        {
            Name = name;
            Usage = usage;
            ActualType = actualType;
        }

        public string Name { get; private set; }
        public string Usage { get; private set; }
    }
}
