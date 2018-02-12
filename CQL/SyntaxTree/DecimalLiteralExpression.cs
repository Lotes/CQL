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
    public class DecimalLiteralExpression: IExpression<DecimalLiteralExpression>
    {
        public readonly double Value;

        public DecimalLiteralExpression(IParserLocation context, double value)
        {
            Value = value;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get { return typeof(double); } }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return Value;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as DecimalLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public DecimalLiteralExpression Validate(IContext context)
        {
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
