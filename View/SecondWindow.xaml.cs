using SunClounds.View;
using System.Windows;

namespace SunClounds
{
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            Weather.Content = new Diagram_Temp();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Weather.Content = new Diagram_Pressure();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Weather.Content = new Diagram_Temp();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Weather.Content = new Diagram_FeelsLike();
        }
    }
}
