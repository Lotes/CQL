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
            Console.WriteLine(CQL.Queries.Parse("a/b OR a / b ORDER BY x ASC SELECT p").ToString());
        }
    }
}
