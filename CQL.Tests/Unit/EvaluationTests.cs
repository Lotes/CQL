using System;
using CQL.TypeSystem.Implementation;
using CQL.Contexts.Implementation;
using CQL.Contexts;
using CQL.ErrorHandling;
using CQL.SyntaxTree;
using NUnit.Framework;

namespace CQL.Tests.Unit
{
    [TestFixture]
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

        [SetUp]
        public void SetupFixture()
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            var Ticket = typeSystemBuilder.AddType<Ticket>("Ticket", "Description of Ticket");
            Ticket.AddForeignProperty(IdDelimiter.Dot, "id", t => t.Id);
            Ticket.AddForeignProperty(IdDelimiter.Dot, "owner", t => t.Owner);
            var typeSystem = typeSystemBuilder.Build();
            context = new EvaluationScope(typeSystem);
            context.DefineForeignGlobalFunction<int, int, int>("max", (a, b) => Math.Max(a, b));
            var String = typeSystem.GetTypeByNative<string>();
            String.AddForeignFunction(IdDelimiter.Dot, "length", str => str.Length);
            String.AddForeignFunction<int, string>(IdDelimiter.Dot, "append", (str, index) => str+index);
            String.AddForeignProperty(IdDelimiter.Dot, "size", str => str.Length);
            String.AddForeignIndexer<int, string>((str, index) => str[index-1].ToString());
            ticketOne = new Ticket(1, "Markus");
            ticketTwo = new Ticket(2, "Jenny");
            ticketThree = new Ticket(3, null);
        }

        [Test]
        public void FunctionEval()
        {
            Assert.IsTrue(Queries.Evaluate("max(100,200) = 200", ticketOne, context) == true);
        }

        [Test]
        public void MethodParameterCoercion()
        {
            Assert.IsTrue(Queries.Evaluate("owner.append(1) = \"Markus1\"", ticketOne, context) == true);
        }

        [Test]
        public void MethodParameterCountMismatch()
        {
            Assert.That(() =>
            {
                Queries.Evaluate("owner.append(1, 3) = \"Markus1\"", ticketOne, context);
            }, Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void AddNumbers()
        {
            Assert.IsTrue(Queries.Evaluate("1 = 0.5 + 0.5", ticketOne, context) == true);
        }

        [Test]
        public void GetTicketByNumber()
        {
            Assert.IsTrue(Queries.Evaluate("id = 1", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("id = 1", ticketTwo, context) == true);
        }

        [Test]
        public void GetTicketByOwner()
        {
            Assert.IsTrue(Queries.Evaluate("owner = \"Markus\"", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("owner = \"Markus\"", ticketTwo, context) == true);
        }

        [Test]
        public void CheckOwnerNull()
        {
            Assert.IsTrue(Queries.Evaluate("NOT(owner IS NULL)", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("owner IS NULL", ticketTwo, context) == true);
            Assert.IsTrue(Queries.Evaluate("owner IS NULL", ticketThree, context) == true);
        }

        [Test]
        public void CheckBuggyIn()
        {
            Assert.That(() => Queries.Evaluate("owner IN owner", ticketOne, context), Throws.TypeOf<LocateableException>());
        }

        [Test]
        public void CheckNestedIn()
        {
            Queries.Evaluate("owner IN [owner]", ticketThree, context);
        }

        [Test]
        public void CheckBuggyContains()
        {
            Queries.Evaluate("owner ~ owner", ticketThree, context);
        }

        [Test]
        public void CheckMethodCall()
        {
            Queries.Evaluate("owner.length() = 6", ticketOne, context);
        }

        [Test]
        public void CheckMember()
        {
            Queries.Evaluate("owner.size = 6", ticketOne, context);
        }

        [Test]
        public void CheckArrayAccess()
        {
            Queries.Evaluate("owner[1] = \"M\"", ticketOne, context);
        }
    }
}
