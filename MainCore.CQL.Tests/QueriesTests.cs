using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MainCore.CQL.Tests
{
    [TestClass]
    public class QueriesTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            CQL.Queries.Parse("a + b");
        }
    }
}
