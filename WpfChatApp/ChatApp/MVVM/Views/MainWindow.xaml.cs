using System.Windows;
using System.Windows.Input;
using ChatApp.MVVM.ViewModel;

namespace ChatApp.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void ShowWindow()
        {
            InitializeComponent();

            _mainViewModel.ApplyData();
            
            DataContext = _mainViewModel;

            Show();
        }
        
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current?.MainWindow == null)
            {
                return;
            }

            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current?.MainWindow == null)
            {
                return;
            }

            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized
                ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current == null)
            {
                return;
            }

            Application.Current.Shutdown();
        }
    }
}
