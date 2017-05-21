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
            typeSystemBuilder.AddType<int>("integer");
            typeSystemBuilder.AddCoercionRule<int, double>(TypeSystem.CoercionKind.Implicit, @int => (double)@int);
            var contextBuilder = new ContextBuilder(typeSystemBuilder.Build());
            contextBuilder.AddField<int, int>("a.b.c", a => 1);
            context = contextBuilder.Build();
        }

        [TestMethod]
        public void MultiIdSuccessTest()
        {
            Queries.Parse("a.b.c = 1", context);
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
    }
}
