using System.Windows;

namespace SunClounds
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*CityCard card = new CityCard();
            card.CityTextBlock.Text = "ПодольскПодольскПодольск";
            listbox.Items.Add(card);
            <ListBox x:Name="listbox" VerticalAlignment="Center" HorizontalAlignment="Center" Width="190" Height="100"></ListBox>*/ //это был тест карточки
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Grid_Main.Visibility = Visibility.Collapsed;
            Window window = new SecondWindow();
            window.Show();
            this.Close();
        }
    }
}
