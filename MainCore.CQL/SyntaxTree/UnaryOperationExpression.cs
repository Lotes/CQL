using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainCore.CQL.Contexts;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem;

namespace MainCore.CQL.SyntaxTree
{
    public class UnaryOperationExpression: IExpression<UnaryOperationExpression>
    {
        public IExpression Expression { get; private set; }
        public readonly UnaryOperator Operator;
        private UnaryOperation operation;

        public UnaryOperationExpression(ParserRuleContext context, UnaryOperator @operator, IExpression expression)
        {
            Expression = expression;
            Operator = @operator;
            ParserContext = context;
        }

        public ParserRuleContext ParserContext { get; private set; }

        public Type SemanticType { get; private set; }

        public bool StructurallyEquals(ISyntaxTreeNode node)
        {
            var other = node as UnaryOperationExpression;
            if (other == null)
                return false;
            return this.Operator == other.Operator
                && this.Expression.StructurallyEquals(other.Expression);
        }

        public override string ToString()
        {
            string opStr;
            switch(Operator)
            {
                case UnaryOperator.Minus: opStr = "-"; break;
                case UnaryOperator.Plus: opStr = "+"; break;
                case UnaryOperator.Not: opStr = "NOT"; break;
                default: throw new InvalidOperationException($"Unhandled operator: {Operator}");
            }
            return $"{opStr} {Expression.ToString()}";
        }

        public UnaryOperationExpression Validate(IContext context)
        {
            Expression = Expression.Validate(context);
            operation = context.TypeSystem.GetUnaryOperation(Operator, Expression.SemanticType);
            if (operation == null)
            {
                throw new LocateableException(ParserContext, "Unary operation not supported for that type of operand!");
            }
            SemanticType = operation.ResultType;
            return this;
        }

        IExpression IExpression.Validate(IContext context)
        {
            return Validate(context);
        }

        public object Evaluate<TSubject>(TSubject subject)
        {
            return operation.Operation(Expression.Evaluate(subject));
        }
    }
}
