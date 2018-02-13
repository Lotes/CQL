using CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Contexts
{
    public interface IContext<TAbstraction>
    {
        ITypeSystem TypeSystem { get; }
        void PushScope();
        void PopScope();
        IScope<TAbstraction> Scope { get; }
        Stack<TAbstraction> Stack { get; }
    }
}
