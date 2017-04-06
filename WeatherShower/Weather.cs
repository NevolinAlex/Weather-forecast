using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherShower
{
    class Forecast
    {
        public string DateTime { get; set; }
        public string Weekday { get; set; }
        public string Pressure { get; set; }
        public string Temperature { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Relwet { get; set; }
        public string Cloudiness { get; set; }
        public string Precipitation { get; set; }
        public string PicturePath { get; set; }
        public Forecast()
        {
        }
    }
}
