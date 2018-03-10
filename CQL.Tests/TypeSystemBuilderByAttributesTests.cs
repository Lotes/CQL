using CQL.Contexts.Implementation;
using CQL.SyntaxTree;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class TypeSystemBuilderByAttributesTests
    {
        private static EvaluationScope scope;

        [CQLType("Ticket", "Object of interest.")]
        public class Ticket
        {
            [CQLGlobalFunction("Max")]
            public static int Max(int a, int b)
            {
                return Math.Max(a, b);
            }

            public Ticket(int id, string owner)
            {
                this.Id = id;
                this.Owner = owner;
            }

            [CQLMemberNativeProperty("Id", IdDelimiter.Dot)]
            public int Id { get; set; }

            [CQLMemberNativeProperty("Owner", IdDelimiter.Dot)]
            public string Owner { get; set; }

            [CQLNativeMemberFunction("toString", IdDelimiter.Dot)]
            public override string ToString() { return "Ticket " + Id; }

            [CQLNativeMemberFunction("call", IdDelimiter.Dot)]
            public void Call() { Console.WriteLine("Hallo?"); }

            [CQLNativeMemberIndexer]
            public string this[int index] { get { return Owner[index].ToString(); } }
        }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            typeSystemBuilder.AddFromScan(typeof(TypeSystemBuilderByAttributesTests));
            var typeSystem = typeSystemBuilder.Build();
            scope = new EvaluationScope(typeSystem);
        }

        [TestMethod]
        public void PropertyTest()
        {
            Assert.IsTrue(Queries.Evaluate("id = 7", new Ticket(7, "Me"), scope) == true);
        }

        [TestMethod]
        public void MemberFunctionTest()
        {
            Assert.IsTrue(Queries.Evaluate("toString() = \"Ticket 7\"", new Ticket(7, "Me"), scope) == true);
        }

        [TestMethod]
        public void MemberActionTest()
        {
            Assert.IsTrue(Queries.Evaluate("not(call() is null)", new Ticket(7, "Me"), scope) == true);
        }

        [TestMethod]
        public void IndexerTest()
        {
            Assert.IsTrue(Queries.Evaluate("this[0] = \"M\"", new Ticket(7, "Me"), scope) == true);
        }
    }
}
