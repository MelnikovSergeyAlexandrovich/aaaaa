using SunClounds.View;
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
using System.Windows.Shapes;

namespace SunClounds
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
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
