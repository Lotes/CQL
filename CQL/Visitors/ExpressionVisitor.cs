using Antlr4.Runtime.Misc;
using CQL.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CQL.CQLParser;

namespace CQL.Visitors
{
    public class ExpressionVisitor : CQLBaseVisitor<IExpression>
    {
        private ExpressionsVisitor exprListVisitor;
        private NameVisitor nameVisitor;

        public ExpressionVisitor()
            : base()
        {
            exprListVisitor = new ExpressionsVisitor(this);
            nameVisitor = new NameVisitor();
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
            return new ConditionalExpression((ParserLocation)context, condition, then, @else);
        }
        public override IExpression VisitOr([NotNull] CQLParser.OrContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Or, lhs, rhs);
        }
        public override IExpression VisitAnd([NotNull] CQLParser.AndContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.And, lhs, rhs);
        }
        public override IExpression VisitEquals([NotNull] CQLParser.EqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Equals, lhs, rhs);
        }
        public override IExpression VisitNotEquals([NotNull] CQLParser.NotEqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.NotEquals, lhs, rhs);
        }
        public override IExpression VisitGt([NotNull] CQLParser.GtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.GreaterThan, lhs, rhs);
        }
        public override IExpression VisitGte([NotNull] CQLParser.GteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.GreaterThanEquals, lhs, rhs);
        }
        public override IExpression VisitLt([NotNull] CQLParser.LtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.LessThan, lhs, rhs);
        }
        public override IExpression VisitLte([NotNull] CQLParser.LteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.LessThanEquals, lhs, rhs);
        }
        public override IExpression VisitPlus([NotNull] CQLParser.PlusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Add, lhs, rhs);
        }
        public override IExpression VisitMinus([NotNull] CQLParser.MinusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Sub, lhs, rhs);
        }
        public override IExpression VisitMul([NotNull] CQLParser.MulContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Mul, lhs, rhs);
        }
        public override IExpression VisitDiv([NotNull] CQLParser.DivContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Div, lhs, rhs);
        }
        public override IExpression VisitMod([NotNull] CQLParser.ModContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Mod, lhs, rhs);
        }
        public override IExpression VisitContains([NotNull] CQLParser.ContainsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Contains, lhs, rhs);
        }
        public override IExpression VisitDoesNotContain([NotNull] CQLParser.DoesNotContainContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.DoesNotContain, lhs, rhs);
        }
        public override IExpression VisitIs([NotNull] CQLParser.IsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Is, lhs, rhs);
        }
        public override IExpression VisitIn([NotNull] CQLParser.InContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.In, lhs, rhs);
        }
        public override IExpression VisitNotIn([NotNull] CQLParser.NotInContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.NotIn, lhs, rhs);
        }
        public override IExpression VisitExpr([NotNull] CQLParser.ExprContext context)
        {
            var expr = Visit(context.expr);
            return new ParenthesisExpression((ParserLocation)context, expr);
        }
        public override IExpression VisitNotFactor([NotNull] CQLParser.NotFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Not, expr);
        }
        public override IExpression VisitMinusFactor([NotNull] CQLParser.MinusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Minus, expr);
        }
        public override IExpression VisitComplexFactor([NotNull] CQLParser.ComplexFactorContext context)
        {
            var primary = Visit(context.pe);
            foreach(var element in context.chain_element())
            {
                if (element is ArrayAccessContext)
                {
                    var arrayAccess = element as ArrayAccessContext;
                    var indices = exprListVisitor.Visit(arrayAccess.elems);
                    primary = new ArrayAccessExpression((ParserLocation)arrayAccess, primary, indices);
                }
                else if (element is MemberCallContext)
                {
                    var memberCall = element as MemberCallContext;
                    var memberName = nameVisitor.Visit(memberCall.id);
                    var delimiter = IdDelimiter.Dot;
                    switch(memberCall.sep.Text)
                    {
                        case "$": delimiter = IdDelimiter.Dollar; break;
                        case ".": delimiter = IdDelimiter.Dot; break;
                        case "#": delimiter = IdDelimiter.Hash; break;
                        case "->": delimiter = IdDelimiter.SingleArrow; break;
                        case "/": delimiter = IdDelimiter.Slash; break;
                    }
                    primary = new MemberCallExpression((ParserLocation)memberCall, primary, delimiter, memberName);
                }
                else if (element is MethodCallContext)
                {
                    var methodCall = element as MethodCallContext;
                    IEnumerable<IExpression> parameters = Enumerable.Empty<IExpression>();
                    if (methodCall.@params != null)
                        parameters = exprListVisitor.Visit(methodCall.@params);
                    primary = new FunctionCallExpression((ParserLocation)methodCall, primary, parameters);
                }
                else
                    throw new InvalidOperationException("Unhandled chain element!");
            }
            return primary;
        }
        public override IExpression VisitPlusFactor([NotNull] CQLParser.PlusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Plus, expr);
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
            return new ArrayExpression((ParserLocation)context, exprListVisitor.Visit(context.elems));
        }
        public override IExpression VisitBracketElems([NotNull] CQLParser.BracketElemsContext context)
        {
            return new ArrayExpression((ParserLocation)context, exprListVisitor.Visit(context.elems));
        }
        public override IExpression VisitParamList([NotNull] CQLParser.ParamListContext context)
        {
            throw new InvalidOperationException("Use ExpressionListVisitor!");
        }
        public override IExpression VisitBool([NotNull] CQLParser.BoolContext context)
        {
            var value = Convert.ToBoolean(nameVisitor.Visit(context.value));
            return new BooleanLiteralExpression((ParserLocation)context, value);
        }
        public override IExpression VisitDecimal([NotNull] CQLParser.DecimalContext context)
        {
            var value = Convert.ToDouble(context.value.Text, CultureInfo.InvariantCulture);
            return new DecimalLiteralExpression((ParserLocation)context, value);
        }
        public override IExpression VisitEmpty([NotNull] CQLParser.EmptyContext context)
        {
            return new EmptyExpression((ParserLocation)context);
        }
        public override IExpression VisitNull([NotNull] CQLParser.NullContext context)
        {
            return new NullExpression((ParserLocation)context);
        }
        public override IExpression VisitString([NotNull] CQLParser.StringContext context)
        {
            var text = context.value.Text;
            var value = text
                .Substring(1, text.Length-2)
                .Unescape()
                ;
            return new StringLiteralExpression((ParserLocation)context, value);
        }
        public override IExpression VisitCastFactor([NotNull] CQLParser.CastFactorContext context)
        {
            var castTypeName = nameVisitor.Visit(context.type);
            var expression = Visit(context.expr);
            return new CastExpression((ParserLocation)context, TypeSystem.CoercionKind.Explicit, castTypeName, expression);
        }
        public override IExpression VisitVarExp([NotNull] CQLParser.VarExpContext context)
        {
            return new VariableExpression((ParserLocation)context, context.var.Text);
        }
    }
}
