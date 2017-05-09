using System;
using MainCore.CQL.TypeSystem;

namespace MainCore.CQL.Contexts.Implementation
{
    public class ContextBuilder : IContextBuilder
    {
        private ITypeSystem typeSystem;
        private FieldSet fields = new FieldSet();
        private FunctionSet functions = new FunctionSet();

        public ContextBuilder(ITypeSystem typeSystem)
        {
            this.typeSystem = typeSystem;
        }

        public void AddField<THost, TField>(string name, Func<THost, TField> getter)
        {
            fields.Add(name, getter);
        }

        public FunctionSet.Function0Builder<TResult> BeginFunction<TResult>(string name, string usage)
        {
            return functions.BeginNew<TResult>(name, usage);
        }

        public IContext Build()
        {
            return new Context(typeSystem, fields, functions);
        }
    }
}
