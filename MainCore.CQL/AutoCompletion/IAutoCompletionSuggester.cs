using System.Collections.Generic;

namespace MainCore.CQL.AutoCompletion
{
    public interface IAutoCompletionSuggester
    {
        IEnumerable<Suggestion> GetSuggestions(string code);
    }
}