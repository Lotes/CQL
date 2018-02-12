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
    public class BooleanLiteralExpression: IExpression<BooleanLiteralExpression>
    {
        public readonly bool Value;

        public BooleanLiteralExpression(IParserLocation context, bool value)
        {
            Value = value;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get { return typeof(bool); } }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return Value;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as BooleanLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public BooleanLiteralExpression Validate(IContext context)
        {
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
