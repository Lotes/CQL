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
        public VariableExpression(IParserLocation location, string identifier)
        {
            this.Location = location;
            this.Name = identifier;
            this.SemanticType = null;
        }

        public string Name { get; private set; }
        public IParserLocation Location { get; private set; }
        public Type SemanticType { get; private set; }

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

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public VariableExpression Validate(IScope<Type> context)
        {
            IVariable<Type> nameable;
            if (!context.TryGetVariable(FullName, out nameable))
                throw new LocateableException(Location, "Unknown field!");
            SemanticType = nameable.Value;
            return this;
        }

        public object Evaluate(IScope<object> context)
        {
            IVariable<object> nameable;
            if (!context.TryGetVariable(FullName, out nameable))
                throw new LocateableException(Location, "Unknown field!");
            return nameable.Value;
        }
    }
}
