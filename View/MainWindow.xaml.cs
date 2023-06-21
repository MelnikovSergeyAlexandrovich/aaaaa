using SunClounds.Model;
using System;
using System.Windows;

namespace SunClounds
{
    public partial class MainWindow : Window
    {
        SecondWindow secondWindow;
        public MainWindow()
        {
            InitializeComponent();
            Themes.Changer(this);
            /*CityCard card = new CityCard();
            card.CityTextBlock.Text = "ПодольскПодольскПодольск";
            listbox.Items.Add(card);
            <ListBox x:Name="listbox" VerticalAlignment="Center" HorizontalAlignment="Center" Width="190" Height="100"></ListBox>*/ //это был тест карточки
        }

        private void SwitchToSecondWindow(object sender, RoutedEventArgs e)
        {
            if(secondWindow == null)
            {
                secondWindow = new SecondWindow();
                secondWindow.Closed += SecondWindow_Closed;
                secondWindow.Owner = this;
            }

            secondWindow.Show();
            Hide();
        }
        private void SecondWindow_Closed(object senser, EventArgs e)
        {
            secondWindow = null;
            Show();
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ResizeButton(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Maximized) 
            {
                WindowState = WindowState.Normal;            
            }
            else
            {
                WindowState = WindowState = WindowState.Maximized;
            }
        }
    }
}
