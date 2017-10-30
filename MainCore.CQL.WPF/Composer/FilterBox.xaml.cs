using GalaSoft.MvvmLight.Command;
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

namespace MainCore.CQL.WPF.Composer
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



        public bool IsLast
        {
            get { return (bool)GetValue(IsLastProperty); }
            set { SetValue(IsLastProperty, value); }
        }
        public static readonly DependencyProperty IsLastProperty =
            DependencyProperty.Register("IsLast", typeof(bool), typeof(FilterBox), new PropertyMetadata(false));



        public RelayCommand AddCommand
        {
            get { return (RelayCommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }
        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(RelayCommand), typeof(FilterBox), new PropertyMetadata(null));




        public RelayCommand DeleteCommand
        {
            get { return (RelayCommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(RelayCommand), typeof(FilterBox), new PropertyMetadata(null));
    }
}
