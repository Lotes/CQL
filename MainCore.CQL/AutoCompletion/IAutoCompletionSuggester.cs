using System.Collections.Generic;

namespace MainCore.CQL.AutoCompletion
{
    public interface IAutoCompletionSuggester
    {
        IEnumerable<int> GetSuggestions(string code);
    }
}