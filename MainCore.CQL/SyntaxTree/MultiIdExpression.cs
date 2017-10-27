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
        public readonly string Name;
        private Type hostType;
        private Func<object, object> getter = null;
        private Func<object, bool> isNull = null;

        public MultiIdExpression(ParserRuleContext context, string name)
        {
            Name = name;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as MultiIdExpression;
            if (other == null)
                return false;
            return this.Name == other.Name;
        }

        public override string ToString()
        {
            return FullName;
        }

        public string FullName { get { return $"{Name}"; } }

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
                hostType = constant.HostType;
                getter = a => constant.Getter(a);
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
    }
}
