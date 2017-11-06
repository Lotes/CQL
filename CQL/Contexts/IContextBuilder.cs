using CQL.Contexts.Implementation;
using System;

namespace CQL.Contexts
{
    public interface IContextBuilder
    {
        void AddField<THost, TField>(string name, string usage, Func<THost, TField> getter, Func<THost, bool> isNull);
        void AddConstant<THost, TField>(string name, string usage, Func<THost, TField> getter);
        ContextBuilder.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage);
        IContext Build();
    }
}
