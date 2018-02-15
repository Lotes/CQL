using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.TypeSystem.Implementation
{
    public class Method : IMethod
    {
        private Delegate body;
        public Method(IdDelimiter delimiter, string name, Type[] formalParameters, Type returnType, Delegate body)
        {

            this.Name = name;
            this.FormalParameters = formalParameters;
            this.ReturnType = returnType;
            this.body = body;
            this.Delimiter = delimiter;
        }

        public IdDelimiter Delimiter { get; private set; }
        public Type[] FormalParameters { get; private set; }
        public string Name { get; private set; }
        public Type ReturnType { get; private set; }
        public object Invoke(object @this, params object[] parameters)
        {
            return body.Method.Invoke(null, new[] { @this }.Concat(parameters).ToArray());
        }
    }
}
