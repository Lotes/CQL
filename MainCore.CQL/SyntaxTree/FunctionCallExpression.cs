using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class FunctionCallExpression: IExpression
    {
        public readonly string Name;
        public readonly IEnumerable<IExpression> Parameters;

        public FunctionCallExpression(ParserRuleContext context, string name, IEnumerable<IExpression> parameters)
        {
            Name = name;
            Parameters = parameters.ToArray();
            ParserContext = context;
        }
        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as FunctionCallExpression;
            if (other == null)
                return false;
            return this.Name == other.Name
                && this.Parameters.StructurallyEquals(other.Parameters);
        }

        public override string ToString()
        {
            return $"{Name}({string.Join(", ", Parameters.Select(p => p.ToString()))})";
        }
    }
}
