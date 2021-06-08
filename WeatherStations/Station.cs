using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStations
{
    class Station
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public double Elevation {get; set;}
        public string ElevationUnit { get; set; }
        public double DataCoverage { get; set; }
}
}
