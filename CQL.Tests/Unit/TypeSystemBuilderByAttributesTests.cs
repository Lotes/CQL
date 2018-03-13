using CQL.Contexts;
using CQL.Contexts.Implementation;
using CQL.SyntaxTree;
using CQL.TypeSystem;
using CQL.TypeSystem.Implementation;
using System;
using NUnit.Framework;

namespace CQL.Tests.Unit
{
    [TestFixture]
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

            [CQLNativeMemberProperty("Id", IdDelimiter.Dot)]
            public int Id { get; set; }

            [CQLNativeMemberProperty("Owner", IdDelimiter.Dot)]
            public string Owner { get; set; }

            [CQLNativeMemberFunction("toString", IdDelimiter.Dot)]
            public override string ToString() { return "Ticket " + Id; }

            [CQLNativeMemberFunction("call", IdDelimiter.Dot)]
            public void Call() { Console.WriteLine("Hallo?"); }

            [CQLNativeMemberIndexer]
            public string this[int index] { get { return Owner[index].ToString(); } }
        }

        [SetUp]
        public void Initialize()
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            typeSystemBuilder.AddFromScan(typeof(TypeSystemBuilderByAttributesTests));
            var typeSystem = typeSystemBuilder.Build();
            scope = new EvaluationScope(typeSystem);
            scope.AddFromScan(typeof(TypeSystemBuilderByAttributesTests));
        }

        [Test]
        public void PropertyTest()
        {
            Assert.IsTrue(Queries.Evaluate("id = 7", new Ticket(7, "Me"), scope) == true);
        }

        [Test]
        public void MemberFunctionTest()
        {
            Assert.IsTrue(Queries.Evaluate("toString() = \"Ticket 7\"", new Ticket(7, "Me"), scope) == true);
        }

        [Test]
        public void MemberActionTest()
        {
            Assert.IsTrue(Queries.Evaluate("call() is null", new Ticket(7, "Me"), scope) == true);
        }

        [Test]
        public void IndexerTest()
        {
            Assert.IsTrue(Queries.Evaluate("this[0] = \"M\"", new Ticket(7, "Me"), scope) == true);
        }

        [Test]
        public void GlobalFunctionTest()
        {
            Assert.IsTrue(Queries.Evaluate("max(1,200) = 200", new Ticket(7, "Me"), scope) == true);
        }
    }
}
