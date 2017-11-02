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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainCore.CQL.SyntaxTree;
using MainCore.CQL.Contexts;

namespace MainCore.CQL.WPF
{
    /// <summary>
    /// Interaktionslogik für Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        public Editor()
        {
            InitializeComponent();
        }

        public bool IsSimple
        {
            get { return (bool)GetValue(IsSimpleProperty); }
            set { SetValue(IsSimpleProperty, value); }
        }
        public static readonly DependencyProperty IsSimpleProperty =
            DependencyProperty.Register("IsSimple", typeof(bool), typeof(Editor), new PropertyMetadata(true));

        public IContext Context
        {
            get { return (IContext)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(IContext), typeof(Editor), new PropertyMetadata(null));
        
        public Query Query
        {
            get { return (Query)GetValue(QueryProperty); }
            set { SetValue(QueryProperty, value); }
        }
        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(Query), typeof(Editor), new PropertyMetadata(null));
    }
}
