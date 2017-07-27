using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using MainCore.CQL.Contexts;
using MainCore.CQL.Contexts.Implementation;
using MainCore.CQL.ErrorHandling;
using MainCore.CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace MainCore.CQL.WPF
{
    /// <summary>
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class TextBox : UserControl
    {
        private TextMarkerService textMarkerService;
        private ToolTip toolTip;
        private IContext context;
        private CompletionWindow completionWindow;

        public TextBox()
        {
            InitializeComponent();
            SetupErrorVisualization();
            SetupSyntaxHighlighting();
            SetupPasting();

            var typeSystemBuilder = new TypeSystemBuilder();
            typeSystemBuilder.AddType<DateTime>("integerxxx", "lol");
            var typeSystem = typeSystemBuilder.Build();
            var contextBuilder = new ContextBuilder(typeSystem);
            contextBuilder.AddField<TextBox, int>("hallo", "hohohooh", t => (int)t.Width, t => true);
            contextBuilder.AddField<TextBox, int>("hillo", "hihihihi", t => (int)t.Width, t => true);
            contextBuilder.BeginFunction<int>("hollu", "lach lach lach").End(() => 3);
            contextBuilder.BeginFunction<int>("hollu2", "lach lach lach").Parameter<int>("alpha", "plopp").End((a) => 3);
            context = contextBuilder.Build();

            textEditor.TextArea.TextEntered += TextArea_TextEntered;
            textEditor.TextArea.PreviewKeyDown += TextArea_PreviewKeyDown;

            textEditor_TextChanged(this, null);
        }

        private void TextArea_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return || e.Key == Key.Enter)
            {
                if (completionWindow != null)
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
                e.Handled = true;
            }
            if (completionWindow == null && e.Key == Key.Space && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                OpenCompletionWindow();
                e.Handled = true;
            }
        }

        private void TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            OpenCompletionWindow();
        }

        private void OpenCompletionWindow()
        {
            // Open code completion after the user has pressed dot:
            completionWindow = new CompletionWindow(textEditor.TextArea);
            IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
            var suggestions = Queries.AutoComplete(textEditor.Text.Substring(0, textEditor.TextArea.Caret.Column - 1), context);
            foreach (var suggestion in suggestions)
                data.Add(new CompletionData(suggestion));
            completionWindow.Show();
            completionWindow.Closed += delegate
            {
                completionWindow = null;
            };
        }

        private void SetupErrorVisualization()
        {
            textMarkerService = new TextMarkerService(textEditor);
            var textView = textEditor.TextArea.TextView;
            textView.BackgroundRenderers.Add(textMarkerService);
            textView.LineTransformers.Add(textMarkerService);
            textView.Services.AddService(typeof(TextMarkerService), textMarkerService);
            textView.MouseHover += MouseHover;
            textView.MouseHoverStopped += TextEditorMouseHoverStopped;
            textView.VisualLinesChanged += VisualLinesChanged;
        }

        private void MouseHover(object sender, MouseEventArgs e)
        {
            var pos = textEditor.TextArea.TextView.GetPositionFloor(e.GetPosition(textEditor.TextArea.TextView) + textEditor.TextArea.TextView.ScrollOffset);
            bool inDocument = pos.HasValue;
            if (inDocument)
            {
                TextLocation logicalPosition = pos.Value.Location;
                int offset = textEditor.Document.GetOffset(logicalPosition);

                var markersAtOffset = textMarkerService.GetMarkersAtOffset(offset);
                TextMarkerService.TextMarker markerWithToolTip = markersAtOffset.FirstOrDefault(marker => marker.ToolTip != null);

                if (markerWithToolTip != null)
                {
                    if (toolTip == null)
                    {
                        toolTip = new ToolTip();
                        toolTip.Closed += ToolTipClosed;
                        toolTip.PlacementTarget = this;
                        toolTip.Content = new TextBlock
                        {
                            Text = markerWithToolTip.ToolTip,
                            TextWrapping = TextWrapping.Wrap
                        };
                        toolTip.IsOpen = true;
                        e.Handled = true;
                    }
                }
            }
        }

        private void ToolTipClosed(object sender, RoutedEventArgs e)
        {
            toolTip = null;
        }

        private void TextEditorMouseHoverStopped(object sender, MouseEventArgs e)
        {
            if (toolTip != null)
            {
                toolTip.IsOpen = false;
                e.Handled = true;
            }
        }

        private void VisualLinesChanged(object sender, EventArgs e)
        {
            if (toolTip != null)
            {
                toolTip.IsOpen = false;
            }
        }

        private void SetupPasting()
        {
            // Find the Paste command of the avalon edit
            foreach (var commandBinding in textEditor.TextArea.CommandBindings.Cast<CommandBinding>())
            {
                if (commandBinding.Command == ApplicationCommands.Paste)
                {
                    // Add a custom PreviewCanExecute handler so we can filter out newlines
                    commandBinding.PreviewCanExecute += new CanExecuteRoutedEventHandler(pasteCommandBinding_PreviewCanExecute);
                    break;
                }
            }
        }

        private void pasteCommandBinding_PreviewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Get clipboard data and stuff
            var dataObject = Clipboard.GetDataObject();
            var text = (string)dataObject.GetData(DataFormats.UnicodeText);
            // normalize newlines so we definitely get all the newlines
            text = TextUtilities.NormalizeNewLines(text, Environment.NewLine);

            // if the text contains newlines - replace them and paste again :)
            if (text.Contains(Environment.NewLine))
            {
                e.CanExecute = false;
                e.Handled = true;
                text = text.Replace(Environment.NewLine, " ");
                Clipboard.SetText(text);
                textEditor.Paste();
            }
        }

        private void SetupSyntaxHighlighting()
        {
            using (var s = new StringReader(Properties.Resources.SyntaxHighlighting))
            using (var reader = new XmlTextReader(s))
                textEditor.SyntaxHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
        }

        private void textEditor_TextChanged(object sender, EventArgs e)
        {
            if (textMarkerService == null)
                return;
            textMarkerService.Clear();
            var errorListener = new ErrorListener();
            errorListener.ErrorDetected += ErrorDetectedErrorListener_ErrorDetected;
            Queries.ParseSemantically(textEditor.Text, context, errorListener);
        }

        private void ErrorDetectedErrorListener_ErrorDetected(object sender, LocateableException e)
        {
            textMarkerService.Create(e.StartIndex, e.Length, e.Message);
        }

        private void textEditor_LostFocus(object sender, RoutedEventArgs e)
        {
        }
    }
}
