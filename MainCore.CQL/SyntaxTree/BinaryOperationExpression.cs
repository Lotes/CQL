using Antlr4.Runtime;
using System;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem;

namespace MainCore.CQL.SyntaxTree
{
    public class BinaryOperationExpression: IExpression<BinaryOperationExpression>
    {
        private IExpression leftExpression;
        private IExpression rightExpression;
        public IExpression LeftExpression { get { return leftExpression; } }
        public IExpression RightExpression { get { return rightExpression; } }
        public readonly BinaryOperator Operator;
        private BinaryOperation operation = null;

        public BinaryOperationExpression(ParserRuleContext context, BinaryOperator @operator, IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
            Operator = @operator;
            ParserContext = context;
            SemanticType = null;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

        public override string ToString()
        {
            string opString;
            switch(Operator)
            {
                case BinaryOperator.Add: opString = "+"; break;
                case BinaryOperator.And: opString = "&&"; break;
                case BinaryOperator.Contains: opString = "~"; break;
                case BinaryOperator.Div: opString = "/"; break;
                case BinaryOperator.DoesNotContain: opString = "!~"; break;
                case BinaryOperator.Equals: opString = "="; break;
                case BinaryOperator.GreaterThan: opString = ">"; break;
                case BinaryOperator.GreaterThanEquals: opString = ">="; break;
                case BinaryOperator.In: opString = "IN"; break;
                case BinaryOperator.Is: opString = "IS"; break;
                case BinaryOperator.IsNot: opString = "IS NOT"; break;
                case BinaryOperator.LessThan: opString = "<"; break;
                case BinaryOperator.LessThanEquals: opString = "<="; break;
                case BinaryOperator.Mod: opString = "%"; break;
                case BinaryOperator.Mul: opString = "*"; break;
                case BinaryOperator.NotEquals: opString = "!="; break;
                case BinaryOperator.NotIn: opString = "NOT IN"; break;
                case BinaryOperator.Or: opString = "||"; break;
                case BinaryOperator.Sub: opString = "-"; break;
                default: throw new InvalidOperationException("Unhandled operator: "+Operator);
            }
            return $"{LeftExpression.ToString()} {opString} {RightExpression.ToString()}";
        }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as BinaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.LeftExpression.StructurallyEquals(other.LeftExpression)
                && this.RightExpression.StructurallyEquals(other.RightExpression);
        }

        public BinaryOperationExpression Validate(IContext context)
        {
            this.leftExpression = this.leftExpression.Validate(context);
            this.rightExpression = this.rightExpression.Validate(context);
            operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
            if(operation == null)
                context.AlignTypes(ref leftExpression, ref rightExpression, 
                    () => new LocateableException(ParserContext, "No binary operation found for given operator"));
            operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
            if(operation == null)
            {
                throw new LocateableException(ParserContext, "No operation found!");
            }
            SemanticType = operation.ResultType;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
