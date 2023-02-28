using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Area4
    {
        public Area5 area { get; set; }
        public string[] weatherCodes { get; set; }
        public string[] weathers { get; set; }
        public string[] winds { get; set; }
        public string[] waves { get; set; }
        public string[] pops { get; set; }
        public string[] temps { get; set; }
        public string[] reliabilities { get; set; }
        public string[] tempsMin { get; set; }
        public string[] tempsMinUpper { get; set; }
        public string[] tempsMinLower { get; set; }
        public string[] tempsMax { get; set; }
        public string[] tempsMaxUpper { get; set; }
        public string[] tempsMaxLower { get; set; }
    }
}
