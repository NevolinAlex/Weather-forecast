using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherShower
{
    class Phenomena
    {
        public int Cloudiness { get; set; }
        public int Precipitation { get; set; }
        public int RPower { get; set; }
        public int SPower { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
