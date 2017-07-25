using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL
{
    public class Token : INameable
    {
        public Token(string name, string usage)
        {
            Name = name;
            Usage = usage;
        }
        public string Name { get; private set; }
        public string Usage { get; private set; }
    }
}
