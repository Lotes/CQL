using System.Collections.Generic;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// Interface providing suggestion on incomplete code.
    /// </summary>
    public interface IAutoCompletionSuggester
    {
        /// <summary>
        /// Returns all possible parts, suggestions, how to continue the code.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Suggestion> GetSuggestions(string code);
    }
}