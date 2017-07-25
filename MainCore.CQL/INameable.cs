using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL
{
    public interface INameable
    {
        string Name { get; }
        string Usage { get; }
    }
}
