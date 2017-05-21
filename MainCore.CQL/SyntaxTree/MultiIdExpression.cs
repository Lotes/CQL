using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;

namespace MainCore.CQL.SyntaxTree
{
    public class MultiIdExpression: IExpression<MultiIdExpression>
    {
        public readonly IEnumerable<TrailingName> TrailingNames;
        public readonly string Name;
        private Field field = null;

        public MultiIdExpression(ParserRuleContext context, string firstName, IEnumerable<TrailingName> trailingNames = null)
        {
            if (trailingNames == null)
                trailingNames = Enumerable.Empty<TrailingName>();
            Name = firstName;
            TrailingNames = trailingNames.ToArray();
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get { return field?.FieldType; } }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MultiIdExpression;
            if (other == null)
                return false;
            return this.Name == other.Name
                && this.TrailingNames.Count() == other.TrailingNames.Count()
                && this.TrailingNames.Zip(other.TrailingNames, (a, b) => a.Name == b.Name && a.Delimiter == b.Delimiter)
                .All(a => a);
        }

        public override string ToString()
        {
            return FullName;
        }

        public string FullName { get { return $"{Name}{string.Join("", TrailingNames.Select(tn => tn.ToString()))}"; } }

        public MultiIdExpression Validate(IContext context)
        {
            var field = context.Fields.Get(FullName);
            if (field == null)
                throw new LocateableException(ParserContext, "Unknown field!");
            this.field = field;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return this.Validate(context);
        }

        public class TrailingName
        {
            public readonly IdDelimiter Delimiter;
            public readonly string Name;

            public TrailingName(IdDelimiter delimiter, string name)
            {
                Delimiter = delimiter;
                Name = name;
            }

            public override string ToString()
            {
                string delimiterString;
                switch (Delimiter)
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
                return $"{delimiterString}{Name}";
            }
        }
    }
}
