using Newtonsoft.Json;
using System.Collections.Generic;

namespace SunClounds
{
    public class Diagram_Data
    {
        public class Main
        {
            public double Temp { get; set; }
            public double feels_like { get; set; }
            public int Pressure { get; set; }
        }
        public class WeatherForecastItem
        {
            [JsonProperty("dt_txt")]
            public string DateTime { get; set; }

            public Main Main { get; set; }
        }
        public class WeatherForecast
        {
            public List<WeatherForecastItem> List { get; set; }
        }
    }

}
