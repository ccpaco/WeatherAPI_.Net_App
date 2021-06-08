using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStations
{
    public class ResultSet
    {
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Limit { get; set; }
    }
    class Metadata
    {
        public ResultSet ResultSet { get; set; }
    }
    // Odd error in VS for Metadata and Results. Says build error and failed, but Console App works just fine. Only outputs 25 results due to data cap
    public class Loader
    {
        public Metadata Metadata { get; set; }
        public Station[] Results { get; set; }
    }
    //Generic Loader
    public class Loader<T>
    {
        public Metadata Metadata { get; set; }
        public T[] Results { get; set; }
    }
}
