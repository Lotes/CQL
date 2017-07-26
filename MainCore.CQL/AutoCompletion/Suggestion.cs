using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainCore.CQL.AutoCompletion
{
    public class Suggestion
    {
        public Suggestion(SuggestionType suggestionType, int position, int selectionLength, string text, string usage)
        {
            Position = position;
            SelectionLength = selectionLength;
            Text = text;
            SuggestionType = suggestionType;
            Usage = usage;
        }
        public int Position { get; private set; }
        public int SelectionLength { get; private set; }
        public string Text { get; private set; }
        public SuggestionType SuggestionType { get; private set; }
        public string Usage { get; private set; }

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

        public override int GetHashCode()
        {
            return new object[] { Position, SelectionLength, Text, SuggestionType, Usage }
                .GetCommonHashCode();
        }
    }
}
