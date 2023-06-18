using SunClounds.View;
using SunClounds.ViewModel;
using System.Windows;

namespace SunClounds
{
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            this.DataContext = new SecondWindowViewModel();
        }
    }
}
