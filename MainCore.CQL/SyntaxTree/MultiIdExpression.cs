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
        private Type hostType;
        private Func<object, object> getter = null;
        private Func<object, bool> isNull = null;

        public MultiIdExpression(ParserRuleContext context, string firstName, IEnumerable<TrailingName> trailingNames = null)
        {
            if (trailingNames == null)
                trailingNames = Enumerable.Empty<TrailingName>();
            Name = firstName;
            TrailingNames = trailingNames.ToArray();
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

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
            var nameable = context.Get(FullName);
            if (nameable == null)
                throw new LocateableException(ParserContext, "Unknown field!");
            if (nameable is Field)
            {
                var field = nameable as Field;
                hostType = field.HostType;
                getter = field.Getter;
                isNull = field.IsNull;
                SemanticType = field.FieldType;
            }
            else if (nameable is Constant)
            {
                var constant = nameable as Constant;
                hostType = typeof(object);
                getter = a => constant.Getter();
                isNull = a => false;
                SemanticType = constant.FieldType;
            }
            else
                throw new LocateableException(ParserContext, "Name must identify a constant or a field.");
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return this.Validate(context);
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            if (!hostType.IsAssignableFrom(typeof(TSubject)) || isNull(subject))
                return null;
            return getter(subject);
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
                }
                return $"{delimiterString}{Name}";
            }
        }
    }
}
