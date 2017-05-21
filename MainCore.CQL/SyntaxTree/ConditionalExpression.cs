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
    public class ConditionalExpression: IExpression<ConditionalExpression>
    {
        public IExpression Condition { get; private set; }
        public IExpression Then { get; private set; }
        public IExpression Else { get; private set; }

        public ConditionalExpression(ParserRuleContext context, IExpression condition, IExpression then, IExpression @else)
        {
            Condition = condition;
            Then = then;
            Else = @else;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

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

        public ConditionalExpression Validate(IContext context)
        {
            Condition = Condition.Validate(context);
            Then = Then.Validate(context);
            Else = Else.Validate(context);
            if (Condition.SemanticType != typeof(bool))
                throw new LocateableException(Condition.ParserContext, "Condition must be a boolean!");
            SemanticType = new[] { Then.SemanticType, Else.SemanticType }.GetCommonBaseClass();
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
