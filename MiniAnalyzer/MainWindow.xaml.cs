using System;
using System.IO;
using System.Windows;
using Utilities;

namespace MiniAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowPreviewDragOver(object sender, DragEventArgs e)
        {
            bool dropEnabled = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length == 1)
                {
                    string fileExtension = Path.GetExtension(files[0]);
                    if (fileExtension.ToLowerInvariant() != FileConstants.JsonExtension)
                    {
                        dropEnabled = false;
                    }
                }
                else
                {
                    dropEnabled = false;
                }
            }
            else
            {
                dropEnabled = false;
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private async void MainWindowDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Length == 1)
            {
                string filePath = files[0];
                if (DataContext is MainWindowViewModel mainWindowVm)
                {
                    await mainWindowVm.LoadJsonFileAsync(filePath);
                }
            }
        }
    }
}
