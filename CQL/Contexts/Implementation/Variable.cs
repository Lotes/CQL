using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts.Implementation
{
    public class Variable<TAbstraction> : IVariable<TAbstraction>
    {
        public Variable(string name, TAbstraction value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public TAbstraction Value { get; set; }
    }
}
