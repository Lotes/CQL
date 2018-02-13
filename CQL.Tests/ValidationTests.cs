using CQL.Contexts;
using CQL.Contexts.Implementation;
using CQL.ErrorHandling;
using CQL.TypeSystem.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Tests
{
    [TestClass]
    public class ValidationTests
    {
        public static IScope context;

        [ClassInitialize]
        public static void SetupFixture(TestContext testContext)
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            var contextBuilder = new ContextBuilder(typeSystemBuilder.Build());
            contextBuilder.AddField<int, int>("a.b.c", "Test variable", a => 1, a => false);
            context = contextBuilder.Build();
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void ExplicitCast_FailMissingCoercionRuleTest()
        {
            Queries.Parse("1 = (integer)1.2", context);
        }

        [TestMethod]
        public void ImplicitCoercion_SuccessTest()
        {
            Queries.Parse("1 = 1.0", context);
        }

        [TestMethod]
        public void MultiId_SuccessTest()
        {
            Queries.Parse("a.b.c = 1.0", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void MultiIdFail_UnknownIdTest()
        {
            Queries.Parse("a.b = 1", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void MultiIdFail_NotBooleanTest()
        {
            Queries.Parse("a.b.c", context);
        }

        [TestMethod]
        public void UnaryOpConstant_SuccessTest()
        {
            Queries.Parse("not true", context);
        }

        [TestMethod]
        public void StringConcat_SuccessTest()
        {
            Queries.Parse("\"a\"+\"b\" = \"ab\"", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void Conditional_FailNoCommonTypeTest()
        {
            Queries.Parse("true ? 123 : \"hallo\"", context);
        }

        [TestMethod]
        public void Conditional_SuccessTest()
        {
            Queries.Parse("(true ? 123 : a.b.c) = 1", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void IsEmpty_FailNoArrayTypeTest()
        {
            Queries.Parse("true IS EMPTY", context);
        }

        [TestMethod]
        public void IsEmpty_SuccessTest()
        {
            Queries.Parse("[a.b.c] IS EMPTY", context);
        }

        [TestMethod]
        public void IsNull_SuccessTest()
        {
            Queries.Parse("a.b.c IS NULL", context);
        }

        [TestMethod]
        public void IsVariableInSet_SuccessTest()
        {
            Queries.Parse("a.b.c in [1]", context);
        }

        [TestMethod]
        public void IsVariableInUnunifiedSet_SuccessTest()
        {
            Queries.Parse("a.b.c in [1.0, 2]", context);
        }
    }
}
