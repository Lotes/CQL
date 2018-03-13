using Antlr4.Runtime;
using System;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.TypeSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CQL.SyntaxTree
{
    /// <summary>
    /// AST node representing binary operator expressions (with two operands).
    /// </summary>
    public class BinaryOperationExpression: IExpression<BinaryOperationExpression>
    {
        private IExpression leftExpression;
        private IExpression rightExpression;
        /// <summary>
        /// Operand on the left side of the operator.
        /// </summary>
        public IExpression LeftExpression { get { return leftExpression; } }
        /// <summary>
        /// Operand on the right side of the operand.
        /// </summary>
        public IExpression RightExpression { get { return rightExpression; } }
        /// <summary>
        /// Binary operator.
        /// </summary>
        public readonly BinaryOperator Operator;
        private BinaryOperation operation = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="operator"></param>
        /// <param name="leftExpression"></param>
        /// <param name="rightExpression"></param>
        public BinaryOperationExpression(IParserLocation context, BinaryOperator @operator, IExpression leftExpression, IExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
            Operator = @operator;
            Location = context;
            SemanticType = null;
        }

        /// <summary>
        /// Validated type.
        /// </summary>
        public Type SemanticType { get; private set; }

        /// <summary>
        /// Position of this expression in the query text.
        /// </summary>
        public IParserLocation Location { get; private set; }
       
        /// <summary>
        /// Outputs user-friendly representation string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string opString;
            switch(Operator)
            {
                case BinaryOperator.Add: opString = "+"; break;
                case BinaryOperator.And: opString = "AND"; break;
                case BinaryOperator.Contains: opString = "~"; break;
                case BinaryOperator.Div: opString = "DIV"; break;
                case BinaryOperator.DoesNotContain: opString = "!~"; break;
                case BinaryOperator.Equals: opString = "="; break;
                case BinaryOperator.GreaterThan: opString = ">"; break;
                case BinaryOperator.GreaterThanEquals: opString = ">="; break;
                case BinaryOperator.In: opString = "IN"; break;
                case BinaryOperator.Is: opString = "IS"; break;
                case BinaryOperator.LessThan: opString = "<"; break;
                case BinaryOperator.LessThanEquals: opString = "<="; break;
                case BinaryOperator.Mod: opString = "MOD"; break;
                case BinaryOperator.Mul: opString = "*"; break;
                case BinaryOperator.NotEquals: opString = "!="; break;
                case BinaryOperator.NotIn: opString = "NOT IN"; break;
                case BinaryOperator.Or: opString = "OR"; break;
                case BinaryOperator.Sub: opString = "-"; break;
                default: throw new InvalidOperationException("Unhandled operator: "+Operator);
            }
            return $"{LeftExpression.ToString()} {opString} {RightExpression.ToString()}";
        }

        /// <summary>
        /// Deep equals.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as BinaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.LeftExpression.StructurallyEquals(other.LeftExpression)
                && this.RightExpression.StructurallyEquals(other.RightExpression);
        }

        /// <summary>
        /// Validation: determines the actual operation and its return type.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public BinaryOperationExpression Validate(IValidationScope context)
        {
            this.leftExpression = this.leftExpression.Validate(context);
            this.rightExpression = this.rightExpression.Validate(context);
            switch (this.Operator)
            {
                case BinaryOperator.In:
                case BinaryOperator.NotIn:
                    {
                        Type needleType = leftExpression.SemanticType;
                        if (!rightExpression.IfArrayTryGetElementType(out Type elementType))
                            throw new LocateableException(Location, "The 'in' operator requires an array expression for the right operand.");
                        if (needleType != elementType)
                        {
                            var chain = context.TypeSystem.GetImplicitlyCastChain(needleType, elementType);
                            var newLeft = chain.ApplyCast(leftExpression, context);
                            if (newLeft != null)
                            {
                                leftExpression = newLeft;
                                needleType = elementType;
                            }
                            else
                            {
                                chain = context.TypeSystem.GetImplicitlyCastChain(elementType, needleType);
                                var array = rightExpression as ArrayExpression;
                                if (array == null)
                                {
                                    throw new LocateableException(Location, "The 'in' operator requires that the right operand to be a list of the left operand's type.");
                                }
                                else
                                {
                                    var newArray = new ArrayExpression(rightExpression.Location, array.Elements.Select(exp => chain.ApplyCast(exp, context)));
                                    if (newArray.Elements.All(e => e != null))
                                    {
                                        rightExpression = newArray;
                                        elementType = needleType;
                                    }
                                    else
                                        throw new LocateableException(Location, "The 'in' operator requires that the left operand has the same type like the elements of the right operand. At least these types must be convertible in each other.");
                                }
                            }
                        }
                        Type haystackType = typeof(IEnumerable<>).MakeGenericType(elementType);
                        var equalsOperator = Operator == BinaryOperator.In ? BinaryOperator.Equals : BinaryOperator.NotEquals;
                        var equals = context.TypeSystem.GetBinaryOperation(equalsOperator, needleType, elementType);
                        if (equals == null)
                            throw new LocateableException(Location, "The elements of the array are not comparable with the left operand.");
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
                    {
                        var negate = false;
                        if (rightExpression is NullExpression)
                        {
                            //almost everything could be null
                            SemanticType = typeof(bool);
                            operation = new BinaryOperation(leftExpression.SemanticType, rightExpression.SemanticType, typeof(bool), Operator,
                                (lhs, _) => { return negate ^ object.Equals(lhs, null); });
                        }
                        else if (rightExpression is EmptyExpression)
                        {
                            if (!leftExpression.IfArrayTryGetElementType(out Type elementType))
                                throw new LocateableException(leftExpression.Location, "Left operand must be of an array type.");
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
                            throw new LocateableException(rightExpression.Location, "Right operand must be NULL or EMPTY.");
                    }
                    break;
                default:
                    operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
                    if (operation == null)
                        context.AlignTypes(ref leftExpression, ref rightExpression,
                            () => new LocateableException(Location, "Binary operation not supported!"));
                    operation = context.TypeSystem.GetBinaryOperation(Operator, LeftExpression.SemanticType, RightExpression.SemanticType);
                    if (operation == null)
                    {
                        throw new LocateableException(Location, "Binary operation not supported!");
                    }
                    SemanticType = operation.ResultType;
                    break;
            }
            return this;
        }

        IExpression IExpression.Validate(IValidationScope context)
        {
            return Validate(context);
        }

        /// <summary>
        /// Evaluation: Executes the binary operation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Evaluate(IEvaluationScope context)
        {
            var lhs = leftExpression.Evaluate(context);
            var rhs = rightExpression.Evaluate(context);
            return operation.Operation(lhs, rhs);
        }
    }
}
