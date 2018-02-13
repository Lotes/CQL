using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public class NullExpression: IExpression<NullExpression>
    {
        public NullExpression(IParserLocation context) { Location = context; }
        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return null;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            return node as NullExpression != null;
        }

        public override string ToString()
        {
            return "NULL";
        }

        public NullExpression Validate(IScope context)
        {
            SemanticType = context.TypeSystem.NullType;
            return this;
        }

        IExpression IExpression.Validate(IScope context)
        {
            return Validate(context);
        }
    }
}
