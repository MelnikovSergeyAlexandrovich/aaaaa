using System.Windows;

namespace SunClounds
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid_Main.Visibility = Visibility.Collapsed;
            Mainwindow.Content = new SecondWindow();
        }
    }
}
