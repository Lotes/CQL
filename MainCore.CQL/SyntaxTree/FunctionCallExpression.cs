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
    }
}
