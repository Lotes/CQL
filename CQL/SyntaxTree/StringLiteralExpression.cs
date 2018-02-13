using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public class StringLiteralExpression: IExpression<StringLiteralExpression>
    {
        public readonly string Value;

        public StringLiteralExpression(IParserLocation context, string value)
        {
            Value = value;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }

        public object Evaluate(IContext<object> context)
        {
            return Value;
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as StringLiteralExpression;
            if (other == null)
                return false;
            return this.Value == other.Value;
        }

        public override string ToString()
        {
            return $"\"{Value.Escape()}\"";
        }

        public StringLiteralExpression Validate(IContext<Type> context)
        {
            SemanticType = typeof(string);
            return this;
        }

        IExpression IExpression.Validate(IContext<Type> context)
        {
            return Validate(context);
        }
    }
}
