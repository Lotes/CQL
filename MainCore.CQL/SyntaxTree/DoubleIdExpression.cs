using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.SyntaxTree
{
    public class DoubleIdExpression: IExpression
    {
        public readonly IdDelimiter Delimiter;
        public readonly string FirstName;
        public readonly string SecondName;

        public DoubleIdExpression(ParserRuleContext context, IdDelimiter delimiter, string firstName, string secondName)
        {
            Delimiter = delimiter;
            FirstName = firstName;
            SecondName = secondName;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as DoubleIdExpression;
            if (other == null)
                return false;
            return this.Delimiter == other.Delimiter
                && this.FirstName == other.FirstName
                && this.SecondName == other.SecondName;
        }

        public override string ToString()
        {
            string delimiterString;
            switch(Delimiter)
            {
                case IdDelimiter.Dollar: delimiterString = "$"; break;
                case IdDelimiter.Dot: delimiterString = "."; break;
                case IdDelimiter.Hash: delimiterString = "#"; break;
                case IdDelimiter.SingleArrow: delimiterString = "->"; break;
                case IdDelimiter.Slash: delimiterString = "/"; break;
                default:
                    throw new InvalidOperationException("Unhandled delimiter!");
                    break;
            }
            return $"{FirstName}{delimiterString}{SecondName}";
        }
    }
}
