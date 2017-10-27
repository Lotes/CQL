using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using MainCore.CQL.AutoCompletion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MainCore.CQL.WPF.Textual
{
    public class CompletionData : ICompletionData
    {
        private static Dictionary<SuggestionType, ImageSource> icons;
        private static ImageSource Convert(Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        static CompletionData()
        {
            icons = new Dictionary<SuggestionType, ImageSource>();
            icons[SuggestionType.Function] = Convert(Properties.Resources.function);
            icons[SuggestionType.Token] = Convert(Properties.Resources.token);
            icons[SuggestionType.Type] = Convert(Properties.Resources.type);
            icons[SuggestionType.Variable] = Convert(Properties.Resources.variable);
        }

        private class SuggestionSegment : ISegment
        {
            public SuggestionSegment(Suggestion suggestion)
            {
                Length = suggestion.SelectionLength;
                Offset = suggestion.Position;
                EndOffset = Offset + Length;
            }
            public int EndOffset { get; private set; }
            public int Length { get; private set; }
            public int Offset { get; private set; }
        }

        private Suggestion suggestion;

        public CompletionData(Suggestion suggestion)
        {
            this.suggestion = suggestion;
        }

        public System.Windows.Media.ImageSource Image { get { return icons[suggestion.SuggestionType]; } }
        public object Content { get { return this.suggestion.Text; } }
        public object Description { get { return suggestion.Usage; } }
        public string Text { get { return suggestion.Text; } }
        public double Priority { get { return 1; } }

        public void Complete(TextArea textArea, ISegment completionSegment,
            EventArgs insertionRequestEventArgs)
        {
            var segment = new SuggestionSegment(suggestion);
            textArea.Document.Replace(segment, this.Text);
        }
    }
}
