using System.Collections.Generic;

namespace CQL.AutoCompletion
{
    public interface IAutoCompletionSuggester
    {
        IEnumerable<Suggestion> GetSuggestions(string code);
    }
}