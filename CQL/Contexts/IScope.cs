using CQL.TypeSystem;
using System.Collections.Generic;

namespace CQL.Contexts
{
    public interface IScope<TAbstraction>
    {
        bool TryGetVariable(string name, out IVariable<TAbstraction> variable);
        IVariable<TAbstraction> DefineVariable(string name, TAbstraction value);
    }
}
