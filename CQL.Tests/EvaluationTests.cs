﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CQL.TypeSystem.Implementation;
using CQL.Contexts.Implementation;
using CQL.Contexts;
using CQL.ErrorHandling;

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

        public static IScope context;
        public static Ticket ticketOne;
        public static Ticket ticketTwo;
        public static Ticket ticketThree;

        [ClassInitialize]
        public static void SetupFixture(TestContext testContext)
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            var contextBuilder = new ContextBuilder(typeSystemBuilder.Build());
            contextBuilder.AddField<Ticket, int>("TicketId", "Number of the ticket", a => a.Id, a => a == null);
            contextBuilder.AddField<Ticket, string>("Owner", "Owner of the ticket", a => a.Owner, a => a == null || a.Owner == null);
            context = contextBuilder.Build();
            ticketOne = new Ticket(1, "Markus");
            ticketTwo = new Ticket(2, "Jenny");
            ticketThree = new Ticket(3, null);
        }

        [TestMethod]
        public void AddNumbers()
        {
            Assert.IsTrue(Queries.Evaluate("1 = 0.5 + 0.5", ticketOne, context) == true);
        }

        [TestMethod]
        public void GetTicketByNumber()
        {
            Assert.IsTrue(Queries.Evaluate("ticketid = 1", ticketOne, context) == true);
            Assert.IsFalse(Queries.Evaluate("ticketid = 1", ticketTwo, context) == true);
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
    }
}