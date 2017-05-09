using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainCore.CQL.SyntaxTree;
using Antlr4.Runtime;

namespace MainCore.CQL.Tests
{
    [TestClass]
    public class ParserTests
    {
        private static ParserRuleContext pc = new ParserRuleContext();
        private void AssertQueryEquals(string actualString, Query expected)
        {
            var actual = Queries.Parse(actualString);
            Assert.IsTrue(actual.StructurallyEquals(expected));
        }

        [TestMethod]
        public void EmptyExpressionTest()
        {
            AssertQueryEquals("empty", new Query(pc, new EmptyExpression(pc)));
        }

        [TestMethod]
        public void NullExpressionTest()
        {
            AssertQueryEquals("null", new Query(pc, new NullExpression(pc)));
        }

        [TestMethod]
        public void FunctionCallExpressionTest()
        {
            AssertQueryEquals("max(1, 2)", new Query(pc, new FunctionCallExpression(pc, "max", new[] 
            {
                new DecimalLiteralExpression(pc, 1),
                new DecimalLiteralExpression(pc, 2)
            })));
        }

        [TestMethod]
        public void VariableExpressionTest()
        {
            AssertQueryEquals("zwerg", new Query(pc, new VariableExpression(pc, "zwerg")));
        }

        [TestMethod]
        public void UnaryOperationExpressionTest()
        {
            AssertQueryEquals("!true", new Query(pc, new UnaryOperationExpression(pc, UnaryOperator.Not, new BooleanLiteralExpression(pc, true))));
        }

        [TestMethod]
        public void BooleanLiteralExpressionTest()
        {
            AssertQueryEquals("true", new Query(pc, new BooleanLiteralExpression(pc, true)));
        }

        [TestMethod]
        public void DecimalLiteralExpressionTest()
        {
            AssertQueryEquals("1", new Query(pc, new DecimalLiteralExpression(pc, 1)));
        }

        [TestMethod]
        public void StringLiteralExpressionTest()
        {
            AssertQueryEquals("\"test\\r\"", new Query(pc, new StringLiteralExpression(pc, "test\r")));
        }

        [TestMethod]
        public void ArrayExpressionTest()
        {
            AssertQueryEquals("[1]", new Query(pc, new ArrayExpression(pc, new[] { new DecimalLiteralExpression(pc, 1) })));
        }

        [TestMethod]
        public void BinaryOperationExpressionTest()
        {
            AssertQueryEquals("1+2", new Query(pc, new BinaryOperationExpression(pc, BinaryOperator.Add, new DecimalLiteralExpression(pc, 1), new DecimalLiteralExpression(pc, 2))));
        }

        [TestMethod]
        public void DoubleIdExpressionTest()
        {
            AssertQueryEquals("a->b", new Query(pc, new DoubleIdExpression(pc, IdDelimiter.SingleArrow, "a", "b")));
        }

        [TestMethod]
        public void CastExpressionTest()
        {
            AssertQueryEquals("(Integer)true", new Query(pc, new CastExpression(pc, "Integer", new BooleanLiteralExpression(pc, true))));
        }

        [TestMethod]
        public void ConditionalExpressionTest()
        {
            AssertQueryEquals("true ? 1 : 2", new Query(pc, new ConditionalExpression(pc, 
                new BooleanLiteralExpression(pc, true), 
                new DecimalLiteralExpression(pc, 1),
                new DecimalLiteralExpression(pc, 2)
            )));
        }

        [TestMethod]
        public void SelectNoNameQuery()
        {
            AssertQueryEquals("1 SELECT a", new Query(pc, new DecimalLiteralExpression(pc, 1), null,
                new[] { new NamedExpression(pc, new VariableExpression(pc, "a")) }));
        }

        [TestMethod]
        public void SelectWithQuery()
        {
            AssertQueryEquals("1 SELECT a AS test", new Query(pc, new DecimalLiteralExpression(pc, 1), null,
                new[] { new NamedExpression(pc, new VariableExpression(pc, "a"), "test") }));
        }

        [TestMethod]
        public void OrderByNoOrder()
        {
            AssertQueryEquals("1 ORDER BY a", new Query(pc, new DecimalLiteralExpression(pc, 1),
                new[] { new OrderExpression(pc, SortOrder.Ascending, new VariableExpression(pc, "a")) }));
        }

        [TestMethod]
        public void OrderByWithOrder()
        {
            AssertQueryEquals("1 ORDER BY a DESC", new Query(pc, new DecimalLiteralExpression(pc, 1),
                new[] { new OrderExpression(pc, SortOrder.Descending, new VariableExpression(pc, "a")) }));
        }
    }
}
