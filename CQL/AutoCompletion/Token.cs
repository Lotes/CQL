using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    public class Token
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
