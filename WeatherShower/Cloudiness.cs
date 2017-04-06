using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherShower
{
    public static class Cloudiness
    {
        public static Dictionary<int, string> couldiness = new Dictionary<int, string>
        {
            [0] = "Fair",
            [1] = "Fair",
            [2] = "Cloudy",
            [3] = "Cloudy",
            [4] = "Rain",
            [5] = "Shower",
            [6] = "Snow",
            [7] = "Snow",
            [8] = "Storm",
            [9] = "No data",
            [10] = "Without precipitation",
        };
        public static string GetByNumber(int value)
        {
            return couldiness[value];
        }
    }
}
