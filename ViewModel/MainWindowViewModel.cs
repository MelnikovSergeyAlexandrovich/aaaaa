using SunClounds.ViewModel.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace SunClounds.ViewModel
{
    internal class MainWindowViewModel : Binding
    {
        #region variables
        MainWindow window;
        public BindableCommand GoToNextPage { get; set; }
        private string _cityInput;
        public string CityInput
        {
            get
            {
                return _cityInput;
            }
            set
            {
                _cityInput = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public MainWindowViewModel(MainWindow window)
        {
            GoToNextPage = new BindableCommand(_ => gotopage());
            this.window = window;
        }
        public void gotopage()
        {
            SecondWindow secondWindow = new SecondWindow();
            window.Visibility = System.Windows.Visibility.Collapsed;
            secondWindow.Show();
        }
    }
}
