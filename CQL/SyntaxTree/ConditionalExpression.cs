using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class ConditionalExpression: IExpression<ConditionalExpression>
    {
        private IExpression @else;
        private IExpression then;

        public IExpression Condition { get; private set; }
        public IExpression Then { get { return then; } }
        public IExpression Else { get { return @else; } }

        public ConditionalExpression(IParserLocation context, IExpression condition, IExpression then, IExpression @else)
        {
            Condition = condition;
            this.then = then;
            this.@else = @else;
            Location = context;
        }

        public IParserLocation Location { get; private set; }

        public Type SemanticType { get; private set; }

        public override string ToString()
        {
            return $"{Condition.ToString()} ? {Then.ToString()} : {Else.ToString()}";
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ConditionalExpression;
            if (other == null)
                return false;
            return this.Condition.StructurallyEquals(other.Condition)
                && this.Then.StructurallyEquals(other.Then)
                && this.Else.StructurallyEquals(other.Else);
        }

        public ConditionalExpression Validate(IScope<Type> context)
        {
            Condition = Condition.Validate(context);
            then = then.Validate(context);
            @else = @else.Validate(context);
            if (Condition.SemanticType != typeof(bool))
                throw new LocateableException(Condition.Location, "Condition must be a boolean!");
            if (Then.SemanticType != Else.SemanticType)
            {
                SemanticType = context.AlignTypes(ref then, ref @else,
                    () => new LocateableException(Location, "In the end the Then and the Else part must have the same type (also using implicit type conversion)!"));
            }
            else
            {
                SemanticType = Then.SemanticType;
            }
            return this;
        }

        IExpression IExpression.Validate(IScope<Type> context)
        {
            return Validate(context);
        }

        public object Evaluate(IScope<object> context)
        {
            var condition = Condition.Evaluate(context);
            if((bool)condition == true)
            {
                return Then.Evaluate(context);
            }
            else
            {
                return Else.Evaluate(context);
            }
        }
    }
}
