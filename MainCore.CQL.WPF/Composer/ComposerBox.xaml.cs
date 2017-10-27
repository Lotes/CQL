using MainCore.CQL.Contexts;
using MainCore.CQL.SyntaxTree;
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

namespace MainCore.CQL.WPF.Composer
{
    public partial class ComposerBox : UserControl
    {
        public ComposerBox()
        {
            InitializeComponent();
        }

        public IContext Context
        {
            get { return (IContext)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public Query Query
        {
            get { return (Query)GetValue(QueryProperty); }
            set { SetValue(QueryProperty, value); }
        }

        public static readonly DependencyProperty ContextProperty =
            DependencyProperty.Register("Context", typeof(IContext), typeof(ComposerBox), new PropertyMetadata(null, contextChangedStatic));

        public static readonly DependencyProperty QueryProperty =
            DependencyProperty.Register("Query", typeof(Query), typeof(ComposerBox), new PropertyMetadata(null, queryChangedStatic));

        private static void contextChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private static void queryChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
