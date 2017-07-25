using MainCore.CQL.AutoCompletion;
using MainCore.CQL.Contexts.Implementation;
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
    public class AutoCompletionTests
    {
        private void Test(string code, params int[] suggestedTokenTypes)
        {
            var typeSystemBuilder = new TypeSystemBuilder();
            var contextBuilder = new ContextBuilder(typeSystemBuilder.Build());
            contextBuilder.AddField<int, int>("a.b.c", "Test variable", a => 1, a => false);
            var context = contextBuilder.Build();
            var suggester = new AutoCompletionSuggester(context);
            var result = suggester.GetSuggestions(code);
            Console.WriteLine(string.Join(",", result.Select(r => r.Name)));
            /*
            var foundButNotExpected = result.FirstOrDefault(it => !suggestedTokenTypes.Contains(it));
            var expectedButNotFound = suggestedTokenTypes.FirstOrDefault(it => !result.Contains(it));
            if (foundButNotExpected != 0)
                throw new InvalidOperationException("Found but not expected: "+foundButNotExpected);
            if (expectedButNotFound != 0)
                throw new InvalidOperationException("Expected but not found: " + expectedButNotFound);
                */
        }

        [TestMethod]
        public void EmptyCode()
        {
            Test("a.", 1, 2, 3);
        }
    }
}
