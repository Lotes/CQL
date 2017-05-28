using MainCore.CQL.Contexts.Implementation;
using System;

namespace MainCore.CQL.Contexts
{
    public interface IContextBuilder
    {
        void AddField<THost, TField>(string name, string usage, Func<THost, TField> getter, Func<THost, bool> isNull);
        void AddConstant<TField>(string name, string usage, Func<TField> getter);
        ContextBuilder.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage);
        IContext Build();
    }
}
