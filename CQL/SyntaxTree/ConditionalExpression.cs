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
    /// <summary>
    /// AST node representing the ternary ?-operator.
    /// </summary>
    public class ConditionalExpression: IExpression<ConditionalExpression>
    {
        private IExpression @else;
        private IExpression then;

        /// <summary>
        /// Condition expression.
        /// </summary>
        public IExpression Condition { get; private set; }
        /// <summary>
        /// Then expression.
        /// </summary>
        public IExpression Then { get { return then; } }
        /// <summary>
        /// Else expression.
        /// </summary>
        public IExpression Else { get { return @else; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="condition"></param>
        /// <param name="then"></param>
        /// <param name="else"></param>
        public ConditionalExpression(IParserLocation context, IExpression condition, IExpression then, IExpression @else)
        {
            Condition = condition;
            this.then = then;
            this.@else = @else;
            Location = context;
        }

        /// <summary>
        /// Location in the query text
        /// </summary>
        public IParserLocation Location { get; private set; }

        /// <summary>
        /// Validated type.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// User-friendly representation as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Condition.ToString()} ? {Then.ToString()} : {Else.ToString()}";
        }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as ConditionalExpression;
            if (other == null)
                return false;
            return this.Condition.StructurallyEquals(other.Condition)
                && this.Then.StructurallyEquals(other.Then)
                && this.Else.StructurallyEquals(other.Else);
        }

        /// <summary>
        /// Validation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ConditionalExpression Validate(IValidationScope context)
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

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Evaluation... does only execute the branch with the corressponding condition 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
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
