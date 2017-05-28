using MainCore.CQL.Contexts;
using MainCore.CQL.Contexts.Implementation;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.Tests
{
    [TestClass]
    public class ValidationTests
    {
        public static IContext context;

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
            Queries.ParseSemantically("1 = (integer)1.2", context);
        }

        [TestMethod]
        public void ImplicitCoercion_SuccessTest()
        {
            Queries.ParseSemantically("1 = 1.0", context);
        }

        [TestMethod]
        public void MultiId_SuccessTest()
        {
            Queries.ParseSemantically("a.b.c = 1.0", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void MultiIdFail_UnknownIdTest()
        {
            Queries.ParseSemantically("a.b = 1", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void MultiIdFail_NotBooleanTest()
        {
            Queries.ParseSemantically("a.b.c", context);
        }

        [TestMethod]
        public void UnaryOpConstant_SuccessTest()
        {
            Queries.ParseSemantically("not true", context);
        }

        [TestMethod]
        public void StringConcat_SuccessTest()
        {
            Queries.ParseSemantically("\"a\"+\"b\" = \"ab\"", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void Conditional_FailNoCommonTypeTest()
        {
            Queries.ParseSemantically("true ? 123 : \"hallo\"", context);
        }

        [TestMethod]
        public void Conditional_SuccessTest()
        {
            Queries.ParseSemantically("(true ? 123 : a.b.c) = 1", context);
        }

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void IsEmpty_FailNoArrayTypeTest()
        {
            Queries.ParseSemantically("true IS EMPTY", context);
        }

        [TestMethod]
        public void IsEmpty_SuccessTest()
        {
            Queries.ParseSemantically("[a.b.c] IS EMPTY", context);
        }

        [TestMethod]
        public void IsNull_SuccessTest()
        {
            Queries.ParseSemantically("a.b.c IS NULL", context);
        }
    }
}
