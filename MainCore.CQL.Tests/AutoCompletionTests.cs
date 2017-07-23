using MainCore.CQL.AutoCompletion;
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
            var suggester = new AutoCompletionSuggester(CQLParser.ruleNames, CQLLexer.DefaultVocabulary, CQLParser._ATN);
            var result = suggester.GetSuggestions(code);
            Console.WriteLine(string.Join(", ", result.Select(r => CQLParser.DefaultVocabulary.GetDisplayName(r))));
            var foundButNotExpected = result.FirstOrDefault(it => !suggestedTokenTypes.Contains(it));
            var expectedButNotFound = suggestedTokenTypes.FirstOrDefault(it => !result.Contains(it));
            if (foundButNotExpected != 0)
                throw new InvalidOperationException("Found but not expected: "+foundButNotExpected);
            if (expectedButNotFound != 0)
                throw new InvalidOperationException("Expected but not found: " + expectedButNotFound);
        }

        [TestMethod]
        public void EmptyCode()
        {
            Test("plopp.", 1, 2, 3);
        }
    }
}
