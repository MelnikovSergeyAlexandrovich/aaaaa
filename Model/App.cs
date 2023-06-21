using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SunClounds.Model
{
    internal class App:Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dic = new ResourceDictionary { Source = new Uri($"pack://application:,,,/StyleLibNet;component/Themes/{value}.xaml", UriKind.Absolute) };
                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dic);




            }
        }
    }
}
