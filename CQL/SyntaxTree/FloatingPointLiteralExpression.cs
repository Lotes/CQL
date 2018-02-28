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
    public class FloatingPointLiteralExpression: IExpression<FloatingPointLiteralExpression>
    {
        public readonly double Value;

        public FloatingPointLiteralExpression(IParserLocation context, double value)
        {
            Value = value;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get { return typeof(double); } }

        public object Evaluate(IScope<object> context)
        {
            return Value;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as FloatingPointLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public FloatingPointLiteralExpression Validate(IScope<Type> context)
        {
            return this;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }
    }
}
