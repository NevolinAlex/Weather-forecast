using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherShower
{
    class PicturePathGetter
    {
        private static readonly Dictionary<int, string> picturePath = new Dictionary<int, string>
        {
            [0] = "Ясно.png",               [20] = "Ясно+дождь.png",
            [1] = "МалоОблачно.png",        [21] = "Пасмурно+дождь.png",
            [2] = "Облачно.png",            [22] = "Пасмурно+дождь.png",
            [3] = "Пасмурно.png",           [23] = "Пасмурно+дождь.png",

            [25] = "Ясно+Ливень.png",       [30] = "Ясно+снег.png",
            [26] = "Пасмурно+ливень.png",   [31] = "Малооблачно+снег.png",
            [27] = "Пасмурно+ливень.png",   [32] = "Облачно+снег.png",
            [28] = "Пасмурно+ливень.png",   [33] = "Пасмурно+снег.png",

            [35] = "Ясно+снег.png",         [40] = "Гроза.png",
            [36] = "Малооблачно+снег.png",  [41] = "Гроза.png",
            [37] = "Облачно+снег.png",      [42] = "Гроза.png",
            [38] = "Пасмурно+снег.png",     [43] = "Гроза.png",

            [45] = "Ясно.png",              [50] = "Ясно.png",
            [46] = "МалоОблачно.png",       [51] = "МалоОблачно.png",
            [47] = "Облачно.png",           [52] = "Облачно.png",
            [48] = "Пасмурно.png",          [53] = "Пасмурно.png"
        };
        public static string GetPicturePath(Phenomena phenomena)
        {
            return @"/WeatherPictures/" + picturePath[phenomena.Cloudiness + 5*phenomena.Precipitation/**Math.Max(phenomena.RPower, phenomena.SPower)*/];
        }
    }
}
