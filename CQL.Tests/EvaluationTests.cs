using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CQL.TypeSystem.Implementation;
using CQL.Contexts.Implementation;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.SyntaxTree;

namespace CQL.Tests
{
    [TestClass]
    public class EvaluationTests
    {
        public class Ticket
        {
            public readonly int Id;
            public readonly string Owner;
            public Ticket(int id, string owner)
            {
                Id = id;
                Owner = owner;
            }
        }

        public static EvaluationScope context;
        public static Ticket ticketOne;
        public static Ticket ticketTwo;
        public static Ticket ticketThree;

        [ClassInitialize]
        public static void SetupFixture(TestContext testContext)
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            var Ticket = typeSystemBuilder.AddType<Ticket>("Ticket", "Description of Ticket");
            Ticket.AddProperty(IdDelimiter.Dot, "id", t => t.Id);
            Ticket.AddProperty(IdDelimiter.Dot, "owner", t => t.Owner);
            var typeSystem = typeSystemBuilder.Build();
            context = new EvaluationScope(typeSystem);
            context.DefineFunction<int, int, int>("max", (a, b) => Math.Max(a, b));
            var String = typeSystem.GetTypeByNative<string>();
            String.AddFunction(IdDelimiter.Dot, "length", str => str.Length);
            String.AddFunction<double, string>(IdDelimiter.Dot, "append", (str, index) => str+index);
            String.AddProperty(IdDelimiter.Dot, "size", str => str.Length);
            String.AddIndexer<int, string>((str, index) => str[index-1].ToString());
            ticketOne = new Ticket(1, "Markus");
            ticketTwo = new Ticket(2, "Jenny");
            ticketThree = new Ticket(3, null);
        }

        [TestMethod]
        public void FunctionEval()
        {
            Assert.IsTrue(Queries.Evaluate("max(100,200) = 200", ticketOne, context) == true);
        }

        [TestMethod]
        public void MethodParameterCoercion()
        {
            Assert.IsTrue(Queries.Evaluate("owner.append(1) = \"Markus1\"", ticketOne, context) == true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MethodParameterCountMismatch()
        {
            Assert.IsTrue(Queries.Evaluate("owner.append(1, 3) = \"Markus1\"", ticketOne, context) == true);
        }

        [TestMethod]
        public void AddNumbers()
        {
            Assert.IsTrue(Queries.Evaluate("1 = 0.5 + 0.5", ticketOne, context) == true);
        }

        [TestMethod]
        public void GetTicketByNumber()
        {
            Assert.IsTrue(Queries.Evaluate("id = 1", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("id = 1", ticketTwo, context) == true);
        }

        [TestMethod]
        public void GetTicketByOwner()
        {
            Assert.IsTrue(Queries.Evaluate("owner = \"Markus\"", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("owner = \"Markus\"", ticketTwo, context) == true);
        }

        [TestMethod]
        public void CheckOwnerNull()
        {
            Assert.IsTrue(Queries.Evaluate("NOT(owner IS NULL)", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("owner IS NULL", ticketTwo, context) == true);
            Assert.IsTrue(Queries.Evaluate("owner IS NULL", ticketThree, context) == true);
        }

        /* HOWTO HANDLE? Currently: NULL + "a" == "a"
        [TestMethod]
        public void CheckConcatOwnerNull()
        {
            Assert.IsFalse(Queries.Evaluate("(owner+\"abc\") IS NULL", ticketOne, context) == true);
            Assert.IsTrue(Queries.Evaluate("(owner+\"abc\") IS NULL", ticketThree, context) == true);
        }*/

        [TestMethod]
        [ExpectedException(typeof(LocateableException))]
        public void CheckBuggyIn()
        {
            Queries.Evaluate("owner IN owner", ticketOne, context);
        }

        [TestMethod]
        public void CheckNestedIn()
        {
            Queries.Evaluate("owner IN [owner]", ticketThree, context);
        }

        [TestMethod]
        public void CheckBuggyContains()
        {
            Queries.Evaluate("owner ~ owner", ticketThree, context);
        }

        [TestMethod]
        public void CheckMethodCall()
        {
            Queries.Evaluate("owner.length() = 6", ticketOne, context);
        }

        [TestMethod]
        public void CheckMember()
        {
            Queries.Evaluate("owner.size = 6", ticketOne, context);
        }

        [TestMethod]
        public void CheckArrayAccess()
        {
            Queries.Evaluate("owner[1] = \"M\"", ticketOne, context);
        }
    }
}
