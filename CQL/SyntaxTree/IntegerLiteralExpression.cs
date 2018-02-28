using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;

namespace CQL.SyntaxTree
{
    public class IntegerLiteralExpression : IExpression<IntegerLiteralExpression>
    {
        public readonly int Value;

        public IntegerLiteralExpression(IParserLocation context, int value)
        {
            Value = value;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get { return typeof(int); } }

        public object Evaluate(IScope<object> context)
        {
            return Value;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as IntegerLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public IntegerLiteralExpression Validate(IScope<Type> context)
        {
            return this;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }
    }
}
