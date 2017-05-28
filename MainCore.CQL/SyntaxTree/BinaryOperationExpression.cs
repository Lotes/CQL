using Antlr4.Runtime;
using System;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem;
using System.Collections;
using System.Collections.Generic;

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
            switch (this.Operator)
            {
                case BinaryOperator.In:
                case BinaryOperator.NotIn:
                    {
                        Type needleType = leftExpression.SemanticType;
                        Type elementType;
                        if (!rightExpression.IfArrayTryGetElementType(out elementType))
                            throw new LocateableException(ParserContext, "The 'in' operator requires an array expression for the right operand.");
                        if(elementType != needleType)
                            throw new LocateableException(ParserContext, "The 'in' operator requires that the left operand has the same type like the elements of the right operand.");
                        Type haystackType = typeof(IEnumerable<>).MakeGenericType(elementType);
                        var equalsOperator = Operator == BinaryOperator.In ? BinaryOperator.Equals : BinaryOperator.NotEquals;
                        var equals = context.TypeSystem.GetBinaryOperation(equalsOperator, needleType, elementType);
                        if (equals == null)
                            throw new LocateableException(ParserContext, "The elements of the array are not comparable with the left operand.");
                        operation = new BinaryOperation(needleType, haystackType, typeof(bool), Operator, (needle, haystack) =>
                        {
                            foreach (object element in ((IEnumerable)haystack))
                                if ((bool)equals.Operation(needle, element) == true)
                                    return true;
                            return false;
                        });
                        SemanticType = typeof(bool);
                    }
                    break;
                case BinaryOperator.Is:
                case BinaryOperator.IsNot:
                    {
                        var negate = Operator == BinaryOperator.IsNot;
                        if (rightExpression is NullExpression)
                        {
                            //almost everything could be null
                            SemanticType = typeof(bool);
                            operation = new BinaryOperation(leftExpression.SemanticType, rightExpression.SemanticType, typeof(bool), Operator,
                                (lhs, _) => { return negate ^ object.Equals(lhs, null); });
                        }
                        else if (rightExpression is EmptyExpression)
                        {
                            Type elementType;
                            if (!leftExpression.IfArrayTryGetElementType(out elementType))
                                throw new LocateableException(leftExpression.ParserContext, "Left operand must be of an array type.");
                            SemanticType = typeof(bool);
                            operation = new BinaryOperation(leftExpression.SemanticType, rightExpression.SemanticType, typeof(bool), Operator,
                                (lhs, _) =>
                                {
                                    foreach (object element in ((IEnumerable)lhs))
                                        return negate;
                                    return !negate;
                                });
                        }
                        else
                            throw new LocateableException(rightExpression.ParserContext, "Right operand must be NULL or EMPTY.");
                    }
                    break;
                default:
                    operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
                    if (operation == null)
                        context.AlignTypes(ref leftExpression, ref rightExpression,
                            () => new LocateableException(ParserContext, "Binary operation not supported!"));
                    operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
                    if (operation == null)
                    {
                        throw new LocateableException(ParserContext, "Binary operation not supported!");
                    }
                    SemanticType = operation.ResultType;
                    break;
            }
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }
    }
}
