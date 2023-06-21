using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SunClounds.Model
{
    internal class Themes
    {
        public Themes() { 
        
        }
        public static ImageBrush BackGround { get; set; }
       public static async Task Changer(MainWindow mainWindow)
        { 
            await Task.Run(() =>
            {
                DateTime dateTime = DateTime.Now;
                if(dateTime.Hour >= 6 && dateTime.Hour <= 3)
                {
                    App.Theme = "Night";

                    BackGround.ImageSource = new BitmapImage(new Uri("pack://application:,,,/StyleLibNet;component/Img/Night.png", UriKind.Absolute));
                    mainWindow.Background = BackGround;
                }
                else if(dateTime.Hour >3 && dateTime.Hour <= 11) {
                    App.Theme = "MorningEvening";
                    BackGround.ImageSource = new BitmapImage(new Uri("Img/MorningEvening.png", UriKind.Relative));
                    mainWindow.Background = BackGround;
                }
                else if (dateTime.Hour >11 && dateTime.Hour <=16) {
                    App.Theme = "Day";
                    BackGround.ImageSource = new BitmapImage(new Uri("pack://application:,,,/StyleLibNet;component/Img/Night.png", UriKind.Absolute));
                    mainWindow.Background = BackGround;
                }
                else
                {
                    App.Theme = "MorningEvening";
                    BackGround.ImageSource = new BitmapImage(new Uri("pack://application:,,,/StyleLibNet;component/Img/MorningEvening.png",UriKind.Absolute));
                    mainWindow.Background = BackGround;
                }
            });
        }
    }
}

