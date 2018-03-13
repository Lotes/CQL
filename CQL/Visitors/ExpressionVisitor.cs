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
    /// <summary>
    /// Visitor producing <see cref="IExpression"/> objects from parts of the abstract syntax tree (AST).
    /// </summary>
    public class ExpressionVisitor : CQLBaseVisitor<IExpression>
    {
        private Regex Pattern_IsFloatingPointNumber = new Regex(@"[\.eE]");
        private ExpressionsVisitor exprListVisitor;
        private NameVisitor nameVisitor;

        /// <summary>
        /// Creates the expression visitor.
        /// </summary>
        public ExpressionVisitor()
            : base()
        {
            exprListVisitor = new ExpressionsVisitor(this);
            nameVisitor = new NameVisitor();
        }

        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ExpressionContext"/>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitExpression([NotNull] CQLParser.ExpressionContext context)
        {
            return Visit(context.ifThenElseTerm());
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ConditionalContext"/>.
        /// Represents the ternary ?-operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitConditional([NotNull] CQLParser.ConditionalContext context)
        {
            var condition = Visit(context.cond);
            var then = Visit(context.then);
            var @else = Visit(context.@else);
            return new ConditionalExpression((ParserLocation)context, condition, then, @else);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.OrContext"/>.
        /// Represents the OR-operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitOr([NotNull] CQLParser.OrContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Or, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.AndContext"/>.
        /// Represents the AND operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitAnd([NotNull] CQLParser.AndContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.And, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.EqualsContext"/>
        /// Represents the = operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitEquals([NotNull] CQLParser.EqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Equals, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.NotEqualsContext"/>.
        /// Represents the != operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitNotEquals([NotNull] CQLParser.NotEqualsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.NotEquals, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.GtContext"/>.
        /// Represents the &gt; operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitGt([NotNull] CQLParser.GtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.GreaterThan, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.GteContext"/>.
        /// Represents the &gt;= operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitGte([NotNull] CQLParser.GteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.GreaterThanEquals, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.LtContext"/>.
        /// Represents the &lt; operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitLt([NotNull] CQLParser.LtContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.LessThan, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.LteContext"/>.
        /// Represents &lt;= operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitLte([NotNull] CQLParser.LteContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.LessThanEquals, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.PlusContext"/>.
        /// Represents addition + operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitPlus([NotNull] CQLParser.PlusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Add, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.MinusContext"/>.
        /// Represents substraction.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitMinus([NotNull] CQLParser.MinusContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Sub, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.MulContext"/>.
        /// Represents multiplication.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitMul([NotNull] CQLParser.MulContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Mul, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.DivContext"/>.
        /// Represents division.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitDiv([NotNull] CQLParser.DivContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Div, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ModContext"/>.
        /// Represents modulo operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitMod([NotNull] CQLParser.ModContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Mod, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ContainsContext"/>.
        /// Represents contains operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitContains([NotNull] CQLParser.ContainsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Contains, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.DoesNotContainContext"/>.
        /// Represents the "does not contain" operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitDoesNotContain([NotNull] CQLParser.DoesNotContainContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.DoesNotContain, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.IsContext"/>.
        /// Represents the IS operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitIs([NotNull] CQLParser.IsContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.Is, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.InContext"/>.
        /// Represents the IN operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitIn([NotNull] CQLParser.InContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.In, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.NotInContext"/>.
        /// Represents the NOT IN operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitNotIn([NotNull] CQLParser.NotInContext context)
        {
            var lhs = Visit(context.lhs);
            var rhs = Visit(context.rhs);
            return new BinaryOperationExpression((ParserLocation)context, BinaryOperator.NotIn, lhs, rhs);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ExprContext"/>.
        /// Represents a expression surrounded by parentheses.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitExpr([NotNull] CQLParser.ExprContext context)
        {
            var expr = Visit(context.expr);
            return new ParenthesisExpression((ParserLocation)context, expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.NotFactorContext"/>.
        /// Represents the NOT operator.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitNotFactor([NotNull] CQLParser.NotFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Not, expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.MinusFactorContext"/>.
        /// Represents numerical negation.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitMinusFactor([NotNull] CQLParser.MinusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Minus, expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ComplexFactorContext"/>.
        /// Represents complex factors like array access, property lookup or function call.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
                    primary = new MemberExpression((ParserLocation)memberCall, primary, delimiter, memberName);
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
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.PlusFactorContext"/>.
        /// Represents unary plus.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitPlusFactor([NotNull] CQLParser.PlusFactorContext context)
        {
            var expr = Visit(context.expr);
            return new UnaryOperationExpression((ParserLocation)context, UnaryOperator.Plus, expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.ConstContext"/>.
        /// Represents several literals.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitConst([NotNull] CQLParser.ConstContext context)
        {
            return Visit(context.expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.LsContext"/>.
        /// Represents array literals.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitLs([NotNull] CQLParser.LsContext context)
        {
            return Visit(context.expr);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.BraceElemsContext"/>.
        /// Represents array literals, too.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitBraceElems([NotNull] CQLParser.BraceElemsContext context)
        {
            return new ArrayExpression((ParserLocation)context, exprListVisitor.Visit(context.elems));
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.BracketElemsContext"/>.
        /// Represents array literal.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitBracketElems([NotNull] CQLParser.BracketElemsContext context)
        {
            return new ArrayExpression((ParserLocation)context, exprListVisitor.Visit(context.elems));
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.BoolContext"/>.
        /// Represents bool literals.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitBool([NotNull] CQLParser.BoolContext context)
        {
            var value = Convert.ToBoolean(nameVisitor.Visit(context.value));
            return new BooleanLiteralExpression((ParserLocation)context, value);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.DecimalContext"/>.
        /// Represents integer and float literals.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitDecimal([NotNull] CQLParser.DecimalContext context)
        {
            if (Pattern_IsFloatingPointNumber.IsMatch(context.value.Text))
            {
                var value = Convert.ToDouble(context.value.Text, CultureInfo.InvariantCulture);
                return new FloatingPointLiteralExpression((ParserLocation)context, value);
            }
            else
            {
                var value = Convert.ToInt32(context.value.Text, CultureInfo.InvariantCulture);
                return new IntegerLiteralExpression((ParserLocation)context, value);
            }
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.EmptyContext"/>.
        /// Represents the EMPTY literal.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitEmpty([NotNull] CQLParser.EmptyContext context)
        {
            return new EmptyExpression((ParserLocation)context);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.NullContext"/>.
        /// Represents a NULL literal.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitNull([NotNull] CQLParser.NullContext context)
        {
            return new NullExpression((ParserLocation)context);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.StringContext"/>.
        /// Represents a string literal.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitString([NotNull] CQLParser.StringContext context)
        {
            var text = context.value.Text;
            var value = text
                .Substring(1, text.Length-2)
                .Unescape()
                ;
            return new StringLiteralExpression((ParserLocation)context, value);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.CastFactorContext"/>.
        /// Represents a type casting expression.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitCastFactor([NotNull] CQLParser.CastFactorContext context)
        {
            var castTypeName = nameVisitor.Visit(context.type);
            var expression = Visit(context.expr);
            return new CastExpression((ParserLocation)context, TypeSystem.CoercionKind.Explicit, castTypeName, expression);
        }
        /// <summary>
        /// Returns expression from parser's <see cref="CQLParser.VarExpContext"/>.
        /// Represents a variable usage.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IExpression VisitVarExp([NotNull] CQLParser.VarExpContext context)
        {
            return new VariableExpression((ParserLocation)context, nameVisitor.Visit(context.p));
        }
    }
}
