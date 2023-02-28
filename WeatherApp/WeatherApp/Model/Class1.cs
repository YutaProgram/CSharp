using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Class1
    {
        public string publishingOffice { get; set; }
        public DateTime reportDatetime { get; set; }
        public Timesery[] timeSeries { get; set; }
        public Tempaverage tempAverage { get; set; }
        public Precipaverage precipAverage { get; set; }
    }
}
