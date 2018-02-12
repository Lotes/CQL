using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;

namespace CQL.SyntaxTree
{
    public class VariableExpression : IExpression<VariableExpression>
    {
        private Type hostType;
        private Func<object, object> getter = null;
        private Func<object, bool> isNull = null;

        public VariableExpression(IParserLocation location, string identifier)
        {
            this.Location = location;
            this.Name = identifier;
            this.SemanticType = null;
        }

        public string Name { get; private set; }
        public IParserLocation Location { get; private set; }
        public Type SemanticType { get; private set; }
        public object Evaluate<TSubject>(TSubject subject)
        {
            if (!hostType.IsAssignableFrom(typeof(TSubject)) || isNull(subject))
                return null;
            return getter(subject);
        }

        public override string ToString()
        {
            return FullName;
        }

        public string FullName { get { return $"{Name}"; } }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as VariableExpression;
            if (other == null)
                return false;
            return other.Name == this.Name;
        }

        IExpression IExpression.Validate(IContext context)
        {
            Validate(context);
            return this;
        }

        public VariableExpression Validate(IContext context)
        {
            var nameable = context.Get(FullName);
            if (nameable == null)
                throw new LocateableException(Location, "Unknown field!");
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
                throw new LocateableException(Location, "Name must identify a constant or a field.");
            return this;
        }
    }
}
