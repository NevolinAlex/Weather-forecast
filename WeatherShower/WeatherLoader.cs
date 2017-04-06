using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherShower
{
    class WeatherLoader
    {
        public List<Forecast> LoadWeather(ComboBoxItem item)
        {
            var doc = XDocument.Load("http://xml.meteoservice.ru/export/gismeteo/point/" + item.Value.ToString() + ".xml");
            var list = new List<Forecast>();
            foreach (var forecast in doc.Root.Descendants("FORECAST"))
            {
                list.Add(GetForecast(forecast));
            }
            return list;
        }
        private Forecast GetForecast(XElement element)
        {
            var forecast = new Forecast();
            var phenomena = new Phenomena();
            var day = Int32.Parse( element.Attribute("day").Value);
            var month = Int32.Parse( element.Attribute("month").Value);
            var year = Int32.Parse( element.Attribute("year").Value);
            var hour = Int32.Parse(element.Attribute("hour").Value);
            forecast.Weekday = ((Weekdays)(int.Parse(element.Attribute("weekday").Value) - 1)).ToString();
            var xmlPhenomena = element.Element("PHENOMENA");
            phenomena.Cloudiness = int.Parse(xmlPhenomena.Attribute("cloudiness").Value);
            phenomena.Precipitation = int.Parse(xmlPhenomena.Attribute("precipitation").Value);
            phenomena.SPower = int.Parse(xmlPhenomena.Attribute("spower").Value);
            phenomena.RPower = int.Parse(xmlPhenomena.Attribute("rpower").Value);
            forecast.PicturePath = PicturePathGetter.GetPicturePath(phenomena);
            forecast.Cloudiness = "Cloudiness: " + Cloudiness.GetByNumber(int.Parse(xmlPhenomena.Attribute("cloudiness").Value));
            forecast.Precipitation = "Precipitation: " + Cloudiness.GetByNumber(int.Parse(xmlPhenomena.Attribute("precipitation").Value));
            forecast.Pressure = "Pressure: " + element.Element("PRESSURE").Attributes().Sum(x => double.Parse(x.Value) / 2).ToString() + " mmHg";
            forecast.Temperature = "Temperature: "+element.Element("TEMPERATURE").Attributes().Sum(x => double.Parse(x.Value) / 2).ToString() + "°";
            var wind = element.Element("WIND");
            forecast.WindSpeed = "Wind speed: " + ((double.Parse(wind.Attribute("max").Value) + double.Parse(wind.Attribute("min").Value)) / 2).ToString() + "m/s";
            forecast.WindDirection = "Directrion: " + ((WindDirection)(int.Parse(wind.Attribute("direction").Value))).ToString();
            forecast.Relwet = "Relwet: " + element.Element("RELWET").Attributes().Sum(x => double.Parse(x.Value) / 2).ToString() + "%";
            forecast.DateTime = new DateTime(year, month, day, hour, 0, 0).ToString("g");
            return forecast;
        }
    }
}
