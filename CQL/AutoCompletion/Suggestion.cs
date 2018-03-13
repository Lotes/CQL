using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.AutoCompletion
{
    /// <summary>
    /// A suggestion from the AutoCompleteSuggester.
    /// </summary>
    public class Suggestion
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="suggestionType"></param>
        /// <param name="position"></param>
        /// <param name="selectionLength"></param>
        /// <param name="text"></param>
        /// <param name="usage"></param>
        public Suggestion(SuggestionType suggestionType, int position, int selectionLength, string text, string usage)
        {
            Position = position;
            SelectionLength = selectionLength;
            Text = text;
            SuggestionType = suggestionType;
            Usage = usage;
        }
        /// <summary>
        /// ??? TODO
        /// </summary>
        public int Position { get; private set; }
        /// <summary>
        /// ??? TODO
        /// </summary>
        public int SelectionLength { get; private set; }
        /// <summary>
        /// Text to be inserted when coosed by user.
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// Type of this suggestion.
        /// </summary>
        public SuggestionType SuggestionType { get; private set; }
        /// <summary>
        /// User documentation
        /// </summary>
        public string Usage { get; private set; }

        /// <summary>
        /// Equals...
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Suggestion;
            if (other == null)
                return false;
            return 
                this.Position == other.Position
                && this.SelectionLength == other.SelectionLength
                && this.Text == other.Text
                && this.SuggestionType == other.SuggestionType
                && this.Usage == other.Usage
                ;
        }
        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return new object[] { Position, SelectionLength, Text, SuggestionType, Usage }
                .GetCommonHashCode();
        }
    }
}
