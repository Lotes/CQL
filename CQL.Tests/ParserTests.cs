using Microsoft.VisualStudio.TestTools.UnitTesting;
using CQL.SyntaxTree;

namespace CQL.Tests
{
    [TestClass]
    public class ParserTests
    {
        private static IParserLocation pc = new ParserLocation(0, 0);
        private void AssertQueryEquals(string actualString, Query expected)
        {
            var actual = Queries.ParseForSyntaxOnly(actualString);
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
            AssertQueryEquals("max(1, 2)", new Query(pc, new FunctionCallExpression(pc, new VariableExpression(pc, "max"), new[] 
            {
                new IntegerLiteralExpression(pc, 1),
                new IntegerLiteralExpression(pc, 2)
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
            AssertQueryEquals("0.5", new Query(pc, new FloatingPointLiteralExpression(pc, 0.5)));
        }

        [TestMethod]
        public void StringLiteralExpressionTest()
        {
            AssertQueryEquals("\"test\\r\"", new Query(pc, new StringLiteralExpression(pc, "test\r")));
        }

        [TestMethod]
        public void ArrayExpressionTest()
        {
            AssertQueryEquals("[1]", new Query(pc, new ArrayExpression(pc, new[] { new IntegerLiteralExpression(pc, 1) })));
        }

        [TestMethod]
        public void BinaryOperationExpressionTest()
        {
            AssertQueryEquals("1+2", new Query(pc, new BinaryOperationExpression(pc, BinaryOperator.Add, new IntegerLiteralExpression(pc, 1), new IntegerLiteralExpression(pc, 2))));
        }

        [TestMethod]
        public void MemberCallExpressionTest()
        {
            AssertQueryEquals("a->b", new Query(pc, new MemberExpression(pc, new VariableExpression(pc, "a"), IdDelimiter.SingleArrow, "b")));
        }

        [TestMethod]
        public void CastExpressionTest()
        {
            AssertQueryEquals("(Integer)true", new Query(pc, new CastExpression(pc, TypeSystem.CoercionKind.Explicit, "Integer", new BooleanLiteralExpression(pc, true))));
        }

        [TestMethod]
        public void ConditionalExpressionTest()
        {
            AssertQueryEquals("true ? 1 : 2", new Query(pc, new ConditionalExpression(pc, 
                new BooleanLiteralExpression(pc, true), 
                new IntegerLiteralExpression(pc, 1),
                new IntegerLiteralExpression(pc, 2)
            )));
        }

        [TestMethod]
        public void MemberFunctionCallExpressionTest()
        {
            AssertQueryEquals("Math.Max(1, 2)", new Query(pc, new FunctionCallExpression(pc, new MemberExpression(pc, new VariableExpression(pc, "Math"), IdDelimiter.Dot, "Max"), new[] 
            {
                new IntegerLiteralExpression(pc, 1),
                new IntegerLiteralExpression(pc, 2)
            })));
        }

        [TestMethod]
        public void IndexerExpressionTest()
        {
            AssertQueryEquals("array[100]", new Query(pc, new ArrayAccessExpression(pc, new VariableExpression(pc, "array"), new[] { new IntegerLiteralExpression(pc, 100) })));
        }
    }
}
