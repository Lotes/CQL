using Antlr4.Runtime.Misc;
using MainCore.CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Visitors
{
    public class ExpressionVisitor : CQLBaseVisitor<IExpression>
    {
        private ExpressionsVisitor exprListVisitor;

        public ExpressionVisitor()
            : base()
        {
            exprListVisitor = new ExpressionsVisitor(this);
        }

        public override IExpression VisitExpression([NotNull] CQLParser.ExpressionContext context)
        {
            return Visit(context.ifThenElseTerm());
        }
        public override IExpression VisitConditional([NotNull] CQLParser.ConditionalContext context)
        {
            var condition = Visit(context.cond);
            var then = Visit(context.then);
            var @else = Visit(context.@else);
            return new ConditionalExpression(context, condition, then, @else);
        }
        public override IExpression VisitOr([NotNull] CQLParser.OrContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Or, lhs, rhs);
        }
        public override IExpression VisitAnd([NotNull] CQLParser.AndContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.And, lhs, rhs);
        }
        public override IExpression VisitEquals([NotNull] CQLParser.EqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Equals, lhs, rhs);
        }
        public override IExpression VisitNotEquals([NotNull] CQLParser.NotEqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.NotEquals, lhs, rhs);
        }
        public override IExpression VisitGt([NotNull] CQLParser.GtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.GreaterThan, lhs, rhs);
        }
        public override IExpression VisitGte([NotNull] CQLParser.GteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.GreaterThanEquals, lhs, rhs);
        }
        public override IExpression VisitLt([NotNull] CQLParser.LtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.LessThan, lhs, rhs);
        }
        public override IExpression VisitLte([NotNull] CQLParser.LteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.LessThanEquals, lhs, rhs);
        }
        public override IExpression VisitPlus([NotNull] CQLParser.PlusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Add, lhs, rhs);
        }
        public override IExpression VisitMinus([NotNull] CQLParser.MinusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Sub, lhs, rhs);
        }
        public override IExpression VisitMul([NotNull] CQLParser.MulContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Mul, lhs, rhs);
        }
        public override IExpression VisitDiv([NotNull] CQLParser.DivContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Div, lhs, rhs);
        }
        public override IExpression VisitMod([NotNull] CQLParser.ModContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Mod, lhs, rhs);
        }
        public override IExpression VisitContains([NotNull] CQLParser.ContainsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Contains, lhs, rhs);
        }
        public override IExpression VisitDoesNotContain([NotNull] CQLParser.DoesNotContainContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.DoesNotContain, lhs, rhs);
        }
        public override IExpression VisitIs([NotNull] CQLParser.IsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.Is, lhs, rhs);
        }
        public override IExpression VisitIsNot([NotNull] CQLParser.IsNotContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.IsNot, lhs, rhs);
        }
        public override IExpression VisitIn([NotNull] CQLParser.InContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.In, lhs, rhs);
        }
        public override IExpression VisitNotIn([NotNull] CQLParser.NotInContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression(context, BinaryOperator.NotIn, lhs, rhs);
        }
        public override IExpression VisitVar([NotNull] CQLParser.VarContext context)
        {
            return new VariableExpression(context, context.var.Text);
        }
        public override IExpression VisitExpr([NotNull] CQLParser.ExprContext context)
        {
            var expr = Visit(context.expr);
            return new ParenthesisExpression(context, expr);
        }
        public override IExpression VisitFunction([NotNull] CQLParser.FunctionContext context)
        {
            var name = context.name.Text;
            var parameters = exprListVisitor.Visit(context.@params);
            return new FunctionCallExpression(context, name, parameters);
        }
        public override IExpression VisitNotFactor([NotNull] CQLParser.NotFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression(context, UnaryOperator.Not, expr);
        }
        public override IExpression VisitMinusFactor([NotNull] CQLParser.MinusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression(context, UnaryOperator.Minus, expr);
        }
        public override IExpression VisitPlusFactor([NotNull] CQLParser.PlusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression(context, UnaryOperator.Plus, expr);
        }
        public override IExpression VisitConst([NotNull] CQLParser.ConstContext context)
        {
            return Visit(context.expr);
        }
        public override IExpression VisitLs([NotNull] CQLParser.LsContext context)
        {
            return Visit(context.expr);
        }
        public override IExpression VisitBraceElems([NotNull] CQLParser.BraceElemsContext context)
        {
            return new ArrayExpression(context, exprListVisitor.Visit(context.elems));
        }
        public override IExpression VisitBracketElems([NotNull] CQLParser.BracketElemsContext context)
        {
            return new ArrayExpression(context, exprListVisitor.Visit(context.elems));
        }
        public override IExpression VisitParamList([NotNull] CQLParser.ParamListContext context)
        {
            throw new InvalidOperationException("Use ExpressionListVisitor!");
        }
        public override IExpression VisitBool([NotNull] CQLParser.BoolContext context)
        {
            var value = Convert.ToBoolean(context.value.Text);
            return new BooleanLiteralExpression(context, value);
        }
        public override IExpression VisitDecimal([NotNull] CQLParser.DecimalContext context)
        {
            var value = Convert.ToDouble(context.value.Text);
            return new DecimalLiteralExpression(context, value);
        }
        public override IExpression VisitEmpty([NotNull] CQLParser.EmptyContext context)
        {
            return new EmptyExpression(context);
        }
        public override IExpression VisitNull([NotNull] CQLParser.NullContext context)
        {
            return new NullExpression(context);
        }
        public override IExpression VisitString([NotNull] CQLParser.StringContext context)
        {
            var text = context.value.Text;
            var value = text
                .Substring(1, text.Length-2)
                .Unescape()
                ;
            return new StringLiteralExpression(context, value);
        }
        public override IExpression VisitTagFactor([NotNull] CQLParser.TagFactorContext context)
        {
            var parts = context.tag.Text.Split('/');
            var category = parts[0];
            var tag = parts[1];
            return new TagExpression(context, category, tag);
        }
        public override IExpression VisitMetricFactor([NotNull] CQLParser.MetricFactorContext context)
        {
            var parts = context.metric.Text.Split('.');
            var sensorType = parts[0];
            var name = parts[1];
            return new MetricExpression(context, sensorType, name);
        }
    }
}
