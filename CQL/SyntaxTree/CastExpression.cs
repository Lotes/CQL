using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;

namespace CQL.SyntaxTree
{
    public class CastExpression : IExpression<CastExpression>
    {
        public readonly CoercionKind Kind;
        public readonly string CastTypeName;
        public IExpression Expression { get; private set; }
        private CoercionRule rule = null;

        public CastExpression(IParserLocation parserContext, CoercionKind kind, string castTypeName, IExpression expression)
        {
            Location = parserContext;
            Kind = kind;
            CastTypeName = castTypeName;
            Expression = expression;
        }

        public CastExpression(CoercionRule rule, IExpression validatedExpression, IScope context)
            : this(validatedExpression.Location, CoercionKind.Implicit, rule.CastingType.Name, validatedExpression)
        {
            this.rule = rule;
            SemanticType = rule.CastingType;
            Expression = validatedExpression;
        }

        public IParserLocation Location { get; private set; }

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
            return (Kind==CoercionKind.Explicit ? $"({CastTypeName})" : "")+Expression.ToString();
        }

        public CastExpression Validate(IScope context)
        {
            var type = context.TypeSystem.GetTypeByName(CastTypeName)?.CSharpType;
            if (type == null)
                throw new LocateableException(Location, $"There is no type {CastTypeName}!");
            Expression = Expression.Validate(context);
            rule = context.TypeSystem.GetCoercionRule(Expression.SemanticType, type);
            if (rule == null)
                throw new LocateableException(Location, $"Can not convert type into a '{CastTypeName}'.");
            SemanticType = type;
            return this;
        }

        IExpression IExpression.Validate(IScope context)
        {
            return this.Validate(context);
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            var operand = Expression.Evaluate(subject);
            return rule.Cast(operand);
        }
    }
}
