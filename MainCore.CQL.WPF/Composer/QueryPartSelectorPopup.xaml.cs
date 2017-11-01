using MainCore.CQL.Contexts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainCore.CQL.WPF.Composer
{
    public partial class QueryPartSelectorPopup : Popup
    {
        public event EventHandler<Suggestion> SuggestionSelected;

        public QueryPartSelectorPopup()
        {
            InitializeComponent();
        }

        public IContext Context
        {
            get { return (Contexts.IContext)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(Contexts.IContext), typeof(QueryPartSelectorPopup), new PropertyMetadata(null, contextChangedStatic));
        private static void contextChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as QueryPartSelectorPopup;
            control.UpdateSuggestions();
        }



        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(QueryPartSelectorPopup), new PropertyMetadata("", filterChangedStatic));
        private static void filterChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as QueryPartSelectorPopup;
            control.ApplyFilter();
        }

        public ObservableCollection<Suggestion> Suggestions
        {
            get { return (ObservableCollection<Suggestion>)GetValue(SuggestionsProperty); }
            set { SetValue(SuggestionsProperty, value); }
        }
        public static readonly DependencyProperty SuggestionsProperty =
            DependencyProperty.Register("Suggestions", typeof(ObservableCollection<Suggestion>), typeof(QueryPartSelectorPopup), new PropertyMetadata(new ObservableCollection<Suggestion>()));

        public ObservableCollection<Suggestion> FilteredSuggestions
        {
            get { return (ObservableCollection<Suggestion>)GetValue(FilteredSuggestionsProperty); }
            set { SetValue(FilteredSuggestionsProperty, value); }
        }
        public static readonly DependencyProperty FilteredSuggestionsProperty =
            DependencyProperty.Register("FilteredSuggestions", typeof(ObservableCollection<Suggestion>), typeof(QueryPartSelectorPopup), new PropertyMetadata(null));

        public Suggestion SelectedSuggestion
        {
            get { return (Suggestion)GetValue(SelectedSuggestionProperty); }
            set { SetValue(SelectedSuggestionProperty, value); }
        }
        public static readonly DependencyProperty SelectedSuggestionProperty =
            DependencyProperty.Register("SelectedSuggestion", typeof(Suggestion), typeof(QueryPartSelectorPopup), new PropertyMetadata(null));

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(QueryPartSelectorPopup), new PropertyMetadata(-1));

        private void UpdateSuggestions()
        {
            Suggestions = new ObservableCollection<Suggestion>();
            foreach (var suggestion in Context.Fields.Select(FieldToSuggestion)
                .Concat(Context.Constants.Where(c => c.FieldType == typeof(bool)).Select(ConstantToSuggestion))
                .Concat(new[]
                {
                    new Suggestion(QueryPartType.BooleanLiteral, "True", "Tautology, everything will be accepted.", true),
                    new Suggestion(QueryPartType.BooleanLiteral, "False", "Contradiction, everything will be rejected.", false)
                })
                .OrderBy(s => s.Name))
                Suggestions.Add(suggestion);
            ApplyFilter();   
        }

        private Suggestion ConstantToSuggestion(Constant constant)
        {
            return new Suggestion(QueryPartType.BooleanConstant, constant.Name, constant.Usage, constant);
        }

        private Suggestion FieldToSuggestion(Field field)
        {
            return new Suggestion(QueryPartType.BooleanConstant, field.Name, field.Usage, field);
        }

        private void ApplyFilter()
        {
            var comparsion = StringComparison.CurrentCultureIgnoreCase;
            var comparer = Comparer<string>.Create((lhs, rhs) => string.Compare(lhs, rhs, comparsion));
            FilteredSuggestions = new ObservableCollection<Suggestion>();
            foreach (var suggestion in Suggestions
                .Where(s => s.Name.IndexOf(FilterText, comparsion) != -1)
                .OrderBy(s => s.Name, comparer))
                FilteredSuggestions.Add(suggestion);
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
            textBoxSearch.Focus();
        }

        private void textBoxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                SelectedIndex--;
                if (SelectedIndex < -1)
                    SelectedIndex = -1;
            }
            else if (e.Key == Key.Down)
            {
                SelectedIndex++;
                if (SelectedIndex >= FilteredSuggestions.Count)
                    SelectedIndex = FilteredSuggestions.Count - 1;
            }
            else if ((e.Key == Key.Enter || e.Key == Key.Return) && SelectedSuggestion != null)
                NotifySuggestionSelected();
            else if (e.Key == Key.Escape)
                IsOpen = false;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedSuggestion != null)
                NotifySuggestionSelected();
        }

        private void NotifySuggestionSelected()
        {
            SuggestionSelected?.Invoke(this, SelectedSuggestion);
            IsOpen = false;
        }
    }
}
