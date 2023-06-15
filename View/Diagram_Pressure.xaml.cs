using Newtonsoft.Json;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;
using static SunClounds.Diagram_Data;

namespace SunClounds.View
{
    public partial class Diagram_Pressure : Page
    {
        private string apiKey = "fb4ec98dbce85ed324c4b036f055f0d9";
        private string city = "Moscow";
        public Diagram_Pressure()
        {
            InitializeComponent();
            Forecast();
            PressurePlotView.Plot.Title("Прогноз погоды");
            PressurePlotView.Plot.XLabel("Время");
            PressurePlotView.Plot.YLabel("Давление");
            PressurePlotView.Configuration.Zoom = false;
            PressurePlotView.Configuration.LockHorizontalAxis = true;
            PressurePlotView.Configuration.LockVerticalAxis = true;
            PressurePlotView.Configuration.Quality = ScottPlot.Control.QualityMode.High;
        }

        private async void Forecast()
        {
            WeatherForecast forecast = await GetWeatherForecast(apiKey, city);

            DateTime currentDateTime = DateTime.Now;

            List<double> pressures = new List<double>();
            List<DateTime> datetimes = new List<DateTime>();

            foreach (WeatherForecastItem item in forecast.List)
            {
                DateTime forecastDateTime = DateTime.Parse(item.DateTime);

                if (forecastDateTime >= currentDateTime && forecastDateTime <= currentDateTime.AddHours(24))
                {
                    double pressure = item.Main.Pressure / 1.333 - 10;
                    pressures.Add(pressure);
                    datetimes.Add(forecastDateTime);
                }
            }

            PlotPressureForecast(datetimes.ToArray(), pressures.ToArray());
        }

        public static async Task<WeatherForecast> GetWeatherForecast(string apiKey, string city)
        {
            string apiUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(json);
                return forecast;
            }
            else
            {
                throw new Exception("Не удалось получить прогноз погоды");
            }
        }

        private void PlotPressureForecast(DateTime[] datetimes, double[] pressures)
        {
            double[] x = datetimes.Select(dt => dt.ToOADate()).ToArray();
            PressurePlotView.Plot.XAxis.ManualTickPositions(x, datetimes.Select(dt => dt.ToString("HH:mm")).ToArray());

            var scatterPlot = PressurePlotView.Plot.AddScatter(x, pressures);
            scatterPlot.MarkerSize = 10;
            scatterPlot.LineWidth = 3;
            scatterPlot.MarkerColor = System.Drawing.Color.BlueViolet;
            scatterPlot.LineColor = System.Drawing.Color.AliceBlue;

            PressurePlotView.Plot.Style(ScottPlot.Style.Pink);
            PressurePlotView.Plot.Grid(lineStyle: LineStyle.None);
            PressurePlotView.Plot.XAxis.DateTimeFormat(true);

            PressurePlotView.Refresh();
        }
    }
}
