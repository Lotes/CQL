using MainCore.CQL.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Contexts.Implementation
{
    public class Context : IContext
    {
        public Context(ITypeSystem typeSystem, IFieldSet fields, IFunctionSet functions)
        {
            TypeSystem = typeSystem;
            Fields = fields;
            Functions = functions;
        }

        public IFieldSet Fields { get; private set; }
        public IFunctionSet Functions { get; private set; }
        public ITypeSystem TypeSystem { get; private set; }
    }
}
