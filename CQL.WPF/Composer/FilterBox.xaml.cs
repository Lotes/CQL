using GalaSoft.MvvmLight.Command;
using CQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CQL.WPF.Composer
{
    /// <summary>
    /// Interaktionslogik für FilterBox.xaml
    /// </summary>
    [ContentProperty("ActualContent")]
    public partial class FilterBox : UserControl
    {
        public FilterBox()
        {
            InitializeComponent();
        }

        public object ActualContent
        {
            get { return (object)GetValue(ActualContentProperty); }
            set { SetValue(ActualContentProperty, value); }
        }
        public static readonly DependencyProperty ActualContentProperty =
            DependencyProperty.Register("ActualContent", typeof(object), typeof(FilterBox), new PropertyMetadata(null));

        public bool IsNegated
        {
            get { return (bool)GetValue(IsNegatedProperty); }
            set { SetValue(IsNegatedProperty, value); }
        }
        
        public static readonly DependencyProperty IsNegatedProperty =
            DependencyProperty.Register("IsNegated", typeof(bool), typeof(FilterBox), new PropertyMetadata(false));



        public IScope Context
        {
            get { return (Contexts.IScope)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(IScope), typeof(FilterBox), new PropertyMetadata(null));



        public bool IsLast
        {
            get { return (bool)GetValue(IsLastProperty); }
            set { SetValue(IsLastProperty, value); }
        }
        public static readonly DependencyProperty IsLastProperty =
            DependencyProperty.Register("IsLast", typeof(bool), typeof(FilterBox), new PropertyMetadata(false));



        public RelayCommand<QueryPartSuggestion> AddCommand
        {
            get { return (RelayCommand<QueryPartSuggestion>)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(RelayCommand<QueryPartSuggestion>), typeof(FilterBox), new PropertyMetadata(null));




        public RelayCommand DeleteCommand
        {
            get { return (RelayCommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(RelayCommand), typeof(FilterBox), new PropertyMetadata(null));



        public FilterBoxState State
        {
            get { return (FilterBoxState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(FilterBoxState), typeof(FilterBox), new PropertyMetadata(FilterBoxState.ReadyToUse));



        public RelayCommand DoneCommand
        {
            get { return (RelayCommand)GetValue(DoneCommandProperty); }
            set { SetValue(DoneCommandProperty, value); }
        }
        public static readonly DependencyProperty DoneCommandProperty =
            DependencyProperty.Register("DoneCommand", typeof(RelayCommand), typeof(FilterBox), new PropertyMetadata(null));




        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            State = FilterBoxState.Editing;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Context == null)
                return;
            var popup = new QueryPartSelectorPopup();
            popup.StaysOpen = false;
            popup.Context = Context;
            popup.PlacementTarget = sender as UIElement;
            popup.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            popup.IsOpen = true;
            popup.SuggestionSelected += Popup_SuggestionSelected;
        }

        private void Popup_SuggestionSelected(object sender, QueryPartSuggestion suggestion)
        {
            AddCommand?.Execute(suggestion);
        }
    }
}
