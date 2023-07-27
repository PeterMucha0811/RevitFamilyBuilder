using System.Windows;
using System.Windows.Input;
using UIAutomation.ViewModels;

namespace UIAutomation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _defaultWindowSize = this.Width;

            // Initialize the MainViewModel and set it as the DataContext of the MainWindow
            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        #region Maximized, Minimize & Collapse Window Options
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool _isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (_isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = _defaultWindowSize;
                    this.Height = 720;

                    _isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    _isMaximized = true;
                }
            }
        }

        private readonly double _defaultWindowSize;
        private bool _isCollapsed = false;

        private void CollapseWindow(object sender, RoutedEventArgs e)
        {
            if (_isCollapsed == false)
            {
                (this as Window).Width = 250;
                _isCollapsed = true;
            }
            else
            {
                (this as Window).Width = _defaultWindowSize;
                _isCollapsed = false;
            }
        }

        #endregion
    }
}



