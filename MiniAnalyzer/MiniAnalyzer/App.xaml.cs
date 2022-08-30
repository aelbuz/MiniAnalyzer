using System.Windows;

namespace MiniAnalyzer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindowViewModel? mainWindowVm;

        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindowVm = new MainWindowViewModel();
            var mainWindow = new MainWindow()
            {
                DataContext = mainWindowVm
            };
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mainWindowVm?.Dispose();

            base.OnExit(e);
        }
    }
}
