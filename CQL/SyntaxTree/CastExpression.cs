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
    /// <summary>
    /// AST node representing one type cast.
    /// </summary>
    public class CastExpression : IExpression<CastExpression>
    {
        /// <summary>
        /// Implicit or explicit cast? Implicits will be created during validation process.
        /// Explicits can be used by the user.
        /// </summary>
        public readonly CoercionKind Kind;
        /// <summary>
        /// The type name which has to be validated.
        /// </summary>
        public readonly string CastTypeName;
        /// <summary>
        /// The source expression which has to be converted.
        /// </summary>
        public IExpression Expression { get; private set; }
        private CoercionRule rule = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parserContext"></param>
        /// <param name="kind"></param>
        /// <param name="castTypeName"></param>
        /// <param name="expression"></param>
        public CastExpression(IParserLocation parserContext, CoercionKind kind, string castTypeName, IExpression expression)
        {
            Location = parserContext;
            Kind = kind;
            CastTypeName = castTypeName;
            Expression = expression;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="validatedExpression"></param>
        public CastExpression(CoercionRule rule, IExpression validatedExpression)
            : this(validatedExpression.Location, CoercionKind.Implicit, rule.CastingType.Name, validatedExpression)
        {
            this.rule = rule;
            SemanticType = rule.CastingType;
            Expression = validatedExpression;
        }

        /// <summary>
        /// Position in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Type of the cast, e.g. the casting type itself.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as CastExpression;
            if (other == null)
                return false;
            return this.CastTypeName == other.CastTypeName
                && this.Expression.StructurallyEquals(other.Expression);
        }

        /// <summary>
        /// Outputs user-friendly representation as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (Kind==CoercionKind.Explicit ? $"({CastTypeName})" : "")+Expression.ToString();
        }

        /// <summary>
        /// Validation: Checks whether the type really exists and whether the conversion is allowed.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public CastExpression Validate(IValidationScope context)
        {
            var type = context.TypeSystem.GetTypeByName(CastTypeName)?.NativeType;
            if (type == null)
                throw new LocateableException(Location, $"There is no type {CastTypeName}!");
            Expression = Expression.Validate(context);
            rule = context.TypeSystem.GetCoercionRule(Expression.SemanticType, type);
            if (rule == null)
                throw new LocateableException(Location, $"Can not convert type into a '{CastTypeName}'.");
            SemanticType = type;
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return this.Validate(context);
        }

        /// <summary>
        /// Evaluation: Casts the input value.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            var operand = Expression.Evaluate(context);
            return rule.Cast(operand);
        }
    }
}
