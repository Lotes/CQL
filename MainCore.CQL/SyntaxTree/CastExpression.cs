using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem;

namespace MainCore.CQL.SyntaxTree
{
    public class CastExpression : IExpression<CastExpression>
    {
        public readonly CoercionKind Kind;
        public readonly string CastTypeName;
        public IExpression Expression { get; private set; }
        private CoercionRule rule = null;

        public CastExpression(ParserRuleContext parserContext, CoercionKind kind, string castTypeName, IExpression expression)
        {
            ParserContext = parserContext;
            Kind = kind;
            CastTypeName = castTypeName;
            Expression = expression;
        }

        public CastExpression(CoercionRule rule, IExpression validatedExpression, IContext context)
            : this(validatedExpression.ParserContext, CoercionKind.Implicit, rule.CastingType.Name, validatedExpression)
        {
            this.rule = rule;
            SemanticType = rule.CastingType;
            Expression = validatedExpression;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as CastExpression;
            if (other == null)
                return false;
            return this.CastTypeName == other.CastTypeName
                && this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            return $"({CastTypeName})"+Expression.ToString();
        }

        public CastExpression Validate(IContext context)
        {
            var type = context.TypeSystem.GetTypeByName(CastTypeName)?.ActualType;
            if (type == null)
                throw new LocateableException(ParserContext, $"There is no type {CastTypeName}!");
            Expression = Expression.Validate(context);
            rule = context.TypeSystem.GetCoercionRule(Expression.SemanticType, type);
            if (rule == null)
                throw new LocateableException(ParserContext, $"Can not convert type into a '{CastTypeName}'.");
            SemanticType = type;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return this.Validate(context);
        }
    }
}
