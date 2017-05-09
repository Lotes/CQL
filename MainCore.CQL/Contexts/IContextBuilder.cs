using MainCore.CQL.Contexts.Implementation;
using System;

namespace MainCore.CQL.Contexts
{
    public interface IContextBuilder
    {
        void AddField<THost, TField>(string name, Func<THost, TField> getter);
        FunctionSet.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage);
        IContext Build();
    }
}
