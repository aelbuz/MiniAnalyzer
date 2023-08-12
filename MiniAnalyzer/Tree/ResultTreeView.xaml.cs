using MiniAnalyzer.Tree.TreeItem;
using System.Windows;
using System.Windows.Controls;

namespace MiniAnalyzer.Tree
{
    /// <summary>
    /// Interaction logic for ResultTreeView.xaml.
    /// </summary>
    public partial class ResultTreeView : TreeView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultTreeView"/> class.
        /// </summary>
        public ResultTreeView()
        {
            InitializeComponent();
        }

        private void TreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeItemViewModelBase treeItem && DataContext is ResultTreeViewModel vm)
            {
                vm.SelectedItem = treeItem;
            }
        }
    }
}
