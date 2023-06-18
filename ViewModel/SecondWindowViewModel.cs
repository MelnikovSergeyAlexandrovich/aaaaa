using SunClounds.View;
using SunClounds.ViewModel.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SunClounds.ViewModel
{
    internal class SecondWindowViewModel : Binding
    {
        #region vatiables
        private Frame _weatherFrame;
        public Frame WeatherFrame
        {
            get
            {
                return _weatherFrame;
            }
            set
            {
                _weatherFrame = value;
                OnPropertyChanged();
            }
        }
        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }
        private string _weather;
        public string Weather
        {
            get
            {
                return _weather;
            }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }
        private string _feels;
        public string Feels
        {
            get
            {
                return _feels;
            }
            set
            {
                _feels = value;
                OnPropertyChanged();
            }
        }
        public BindableCommand temperature;
        public BindableCommand pressure;
        public BindableCommand feels;
        public SecondWindowViewModel()
        {
            WeatherFrame.Content = new Diagram_Temp();
            temperature = new BindableCommand(_ => showTemperature());
            pressure = new BindableCommand(_ => showPressure());
            feels = new BindableCommand(_ => showFeels());
        }
        public void showTemperature()
        {
            WeatherFrame.Content = new Diagram_Temp();
        }
        public void showPressure()
        {
            WeatherFrame.Content = new Diagram_Pressure();
        }
        public void showFeels()
        {
            WeatherFrame.Content = new Diagram_FeelsLike();
        }

        #endregion
    }
}
