using System.Windows;
using ChatApp.Core;
using ChatApp.MVVM.Views;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ViewFactory _viewFactory;

        public App(ViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

            //initialize your app
        }
        
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginView = _viewFactory.Get<MainWindow>();

            loginView.ShowWindow();
        }
    }
}
