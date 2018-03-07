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
            public Ticket(int id, string owner)
            {
                this.Id = id;
                this.Owner = owner;
            }

            [CQLProperty("Id", IdDelimiter.Dot)]
            public int Id { get; set; }

            [CQLProperty("Owner", IdDelimiter.Dot)]
            public string Owner { get; set; }

            [CQLMethod("toString", IdDelimiter.Dot)]
            public override string ToString() { return "Ticket " + Id; }
            [CQLIndexer]
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
            Assert.IsTrue(Queries.Evaluate<Ticket>("id = 7", new Ticket(7, "Me"), scope) == true);
        }
    }
}
