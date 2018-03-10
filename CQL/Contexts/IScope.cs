using CQL.Contexts.Implementation;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace CQL.Contexts
{
    public interface IScope<TAbstraction>: IEnumerable<IVariable<TAbstraction>>
    {
        ITypeSystem TypeSystem { get; }
        bool TryGetVariable(string name, out IVariable<TAbstraction> variable);
        IVariable<TAbstraction> DefineVariable(string name, TAbstraction value);
        IScope<TAbstraction> Parent { get; }
    }
}
