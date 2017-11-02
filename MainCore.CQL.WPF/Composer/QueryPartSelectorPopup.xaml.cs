using GalaSoft.MvvmLight.CommandWpf;
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
        public event EventHandler<QueryPartSuggestion> SuggestionSelected;

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

        public ObservableCollection<QueryPartSuggestion> Suggestions
        {
            get { return (ObservableCollection<QueryPartSuggestion>)GetValue(SuggestionsProperty); }
            set { SetValue(SuggestionsProperty, value); }
        }
        public static readonly DependencyProperty SuggestionsProperty =
            DependencyProperty.Register("Suggestions", typeof(ObservableCollection<QueryPartSuggestion>), typeof(QueryPartSelectorPopup), new PropertyMetadata(new ObservableCollection<QueryPartSuggestion>()));

        public ObservableCollection<QueryPartSuggestion> FilteredSuggestions
        {
            get { return (ObservableCollection<QueryPartSuggestion>)GetValue(FilteredSuggestionsProperty); }
            set { SetValue(FilteredSuggestionsProperty, value); }
        }
        public static readonly DependencyProperty FilteredSuggestionsProperty =
            DependencyProperty.Register("FilteredSuggestions", typeof(ObservableCollection<QueryPartSuggestion>), typeof(QueryPartSelectorPopup), new PropertyMetadata(null));

        public QueryPartSuggestion SelectedSuggestion
        {
            get { return (QueryPartSuggestion)GetValue(SelectedSuggestionProperty); }
            set { SetValue(SelectedSuggestionProperty, value); }
        }
        public static readonly DependencyProperty SelectedSuggestionProperty =
            DependencyProperty.Register("SelectedSuggestion", typeof(QueryPartSuggestion), typeof(QueryPartSelectorPopup), new PropertyMetadata(null));

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(QueryPartSelectorPopup), new PropertyMetadata(-1));

        private void UpdateSuggestions()
        {
            Suggestions = new ObservableCollection<QueryPartSuggestion>();
            foreach (var suggestion in Context.Fields.Select(FieldToSuggestion)
                .Concat(Context.Constants.Where(c => c.FieldType == typeof(bool)).Select(ConstantToSuggestion))
                .Concat(new[]
                {
                    new QueryPartSuggestion("True", "Tautology, everything will be accepted.", new BooleanLiteralViewModel(true)),
                    new QueryPartSuggestion("False", "Contradiction, everything will be rejected.", new BooleanLiteralViewModel(false))
                })
                .OrderBy(s => s.Name))
                Suggestions.Add(suggestion);
            ApplyFilter();   
        }

        private QueryPartSuggestion ConstantToSuggestion(Constant constant)
        {
            return new QueryPartSuggestion(constant.Name, constant.Usage, new BooleanConstantViewModel(Context, constant));
        }

        private QueryPartSuggestion FieldToSuggestion(Field field)
        {
            return new QueryPartSuggestion(field.Name, field.Usage, new FieldComparsionViewModel(Context, field));
        }

        private void ApplyFilter()
        {
            var comparsion = StringComparison.CurrentCultureIgnoreCase;
            var comparer = Comparer<string>.Create((lhs, rhs) => string.Compare(lhs, rhs, comparsion));
            FilteredSuggestions = new ObservableCollection<QueryPartSuggestion>();
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

        private void NotifySuggestionSelected()
        {
            SuggestionSelected?.Invoke(this, SelectedSuggestion);
            IsOpen = false;
        }

        private void ListBox_Click(object sender, MouseButtonEventArgs e)
        {
            if (SelectedSuggestion != null)
                NotifySuggestionSelected();
        }
    }
}
