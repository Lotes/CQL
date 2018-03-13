using CQL.Contexts;
using CQL.Contexts.Implementation;
using CQL.ErrorHandling;
using CQL.SyntaxTree;
using CQL.TypeSystem.Implementation;
using NUnit.Framework;

namespace CQL.Tests.Unit
{
    [TestFixture]
    public class ValidationTests
    {
        public class A
        {
            public B b { get; set; }
        }

        public class B
        {
            public int c { get; set; }
        }

        public static IEvaluationScope context;

        [SetUp]
        public void SetupFixture()
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            typeSystemBuilder.AddType<A>("A", "stuff").AddForeignProperty(IdDelimiter.Dot, "b", a => a.b);
            typeSystemBuilder.AddType<B>("B", "stuff 2").AddForeignProperty(IdDelimiter.Dot, "c", a => a.c);
            context = new EvaluationScope(typeSystemBuilder.Build());
            context.DefineVariable("a", new A() { b = new B() { c = 1 } });
        }

        [Test]
        public void ExplicitCast_FailMissingCoercionRuleTest()
        {
            Assert.That(() =>
            {
                Queries.Parse("1 = (integer)1.2", context);
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void ImplicitCoercion_SuccessTest()
        {
            Queries.Parse("1 = 1.0", context);
        }

        [Test]
        public void VariableProperties_SuccessTest()
        {
            Queries.Parse("a.b.c = 1.0", context);
        }

        [Test]
        public void VariablePropertiesFail_UnknownIdTest()
        {
            Assert.That(() =>
            {
                Queries.Parse("a.b = 1", context);
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void VariablePropertiesFail_NotBooleanTest()
        {
            Assert.That(() =>
            {
                Queries.Parse("a.b.c", context);
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void UnaryOpConstant_SuccessTest()
        {
            Queries.Parse("not true", context);
        }

        [Test]
        public void StringConcat_SuccessTest()
        {
            Queries.Parse("\"a\"+\"b\" = \"ab\"", context);
        }

        [Test]
        public void Conditional_FailNoCommonTypeTest()
        {
            Assert.That(() =>
            {
                Queries.Parse("true ? 123 : \"hallo\"", context);
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void Conditional_SuccessTest()
        {
            Queries.Parse("(true ? 123 : a.b.c) = 1", context);
        }

        [Test]
        public void IsEmpty_FailNoArrayTypeTest()
        {
            Assert.That(() =>
            {
                Queries.Parse("true IS EMPTY", context);    
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void IsEmpty_SuccessTest()
        {
            Queries.Parse("[a.b.c] IS EMPTY", context);
        }

        [Test]
        public void IsNull_SuccessTest()
        {
            Queries.Parse("a.b.c IS NULL", context);
        }

        [Test]
        public void IsVariableInSet_SuccessTest()
        {
            Queries.Parse("a.b.c in [1]", context);
        }

        [Test]
        public void IsVariableInUnunifiedSet_SuccessTest()
        {
            Queries.Parse("a.b.c in [1.0, 2]", context);
        }
    }
}
