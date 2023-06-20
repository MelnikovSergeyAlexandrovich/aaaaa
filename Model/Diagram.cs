using Newtonsoft.Json;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SunClounds.Diagram_Data;

namespace SunClounds.Model
{
    internal class Diagram_view
    {
        public int variable;
        private WpfPlot plotView;
        private string apiKey = "fb4ec98dbce85ed324c4b036f055f0d9";
        private string city = "Moscow";
        public Diagram_view(WpfPlot plotView, int variable)
        {
            this.plotView = plotView;
            ConfigurePlot();
            this.variable = variable;
        }

        private void ConfigurePlot()
        {
            plotView.Plot.XLabel("Время");
            plotView.Plot.Title("Прогноз погоды");
            plotView.Configuration.Zoom = false;
            plotView.Configuration.LockHorizontalAxis = true;
            plotView.Configuration.LockVerticalAxis = true;
            plotView.Configuration.Quality = ScottPlot.Control.QualityMode.High;
            Forecast();
        }

        private async void Forecast()
        {
            WeatherForecast forecast = await GetWeatherForecast(apiKey, city);

            DateTime currentDateTime = DateTime.Now;

            List<double> feels = new List<double>();
            List<DateTime> datetimes = new List<DateTime>();

            foreach (WeatherForecastItem item in forecast.List)
            {
                DateTime forecastDateTime = DateTime.Parse(item.DateTime);

                if (forecastDateTime >= currentDateTime && forecastDateTime <= currentDateTime.AddHours(24))
                {
                    if (variable == 0)
                    {
                        double temp = item.Main.Temp - 273;
                        feels.Add(Math.Round(temp, 0));
                        datetimes.Add(forecastDateTime);
                    }
                    else if(variable == 1)
                    {
                        double feels_like = item.Main.feels_like - 273;
                        feels.Add(Math.Round(feels_like, 0));
                        datetimes.Add(forecastDateTime);
                    }
                    else if(variable == 2)
                    {
                        double pres = item.Main.Pressure / 1.333 - 10;
                        feels.Add(Math.Round(pres, 0));
                        datetimes.Add(forecastDateTime);
                    }
                }
            }
            PlotForecast(datetimes.ToArray(), feels.ToArray());
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

        private void PlotForecast(DateTime[] datetimes, double[] list)
        {
            double[] x = datetimes.Select(dt => dt.ToOADate()).ToArray();
            plotView.Plot.XAxis.ManualTickPositions(x, datetimes.Select(dt => dt.ToString("HH:mm")).ToArray());

            var scatterPlot = plotView.Plot.AddScatter(x, list);
            scatterPlot.MarkerSize = 10;
            scatterPlot.LineWidth = 3;
            scatterPlot.MarkerColor = System.Drawing.Color.BlueViolet;
            scatterPlot.LineColor = System.Drawing.Color.AliceBlue;

            plotView.Plot.Style(ScottPlot.Style.Pink);
            plotView.Plot.Grid(lineStyle: LineStyle.None);
            plotView.Plot.XAxis.DateTimeFormat(true);

            plotView.Refresh();
        }
    }
}
