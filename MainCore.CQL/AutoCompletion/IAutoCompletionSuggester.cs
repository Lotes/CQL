using System.Collections.Generic;

namespace MainCore.CQL.AutoCompletion
{
    public interface IAutoCompletionSuggester
    {
        IEnumerable<INameable> GetSuggestions(string code);
    }
}