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
        public object Evaluate(IContext<object> subject)
        {
            if (isNull(subject))
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

        IExpression IExpression.Validate(IContext<Type> context)
        {
            Validate(context);
            return this;
        }

        public VariableExpression Validate(IContext<Type> context)
        {
            IVariable<Type> nameable;
            if (!context.Scope.TryGetVariable(FullName, out nameable))
                throw new LocateableException(Location, "Unknown field!");
            //TODO
            throw new LocateableException(Location, "Name must identify a constant or a field.");
            //return this;
        }
    }
}
