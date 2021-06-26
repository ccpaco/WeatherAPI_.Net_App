using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherStations
{
  
    class Program
    {
        // Web Services Docs: https://www.ncdc.noaa.gov/cdo-web/webservices/v2#stations
        private const string BaseUrl = "https://www.ncdc.noaa.gov/cdo-web/api/v2/";
        // Tokens are unique. Request on NOAA website, receive via email
        private const string Token = "yourStringKeyHere";
        private static bool AreRequestsCompleted = false;
        static void Main(string[] args)
        {
            LoadStations();
            Console.ReadLine();
            while (!AreRequestsCompleted) Thread.Sleep(1000);
        }

        private async static void LoadStations()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("TOKEN", Token);
                string result = await client.GetStringAsync(BaseUrl + "stations");
                //install Json Newsoft package for JsonConvert 
                /*dynamic jsonObj = JsonConvert.DeserializeObject(result);
                var resultset = jsonObj.metadata.resultset;
                Console.WriteLine($"Total # Stations: {resultset.count}\t# Retrieved: {resultset.limit}");
                var results = jsonObj.results;
                Console.WriteLine($"Result array contains {results.Count} stations.");
                foreach (dynamic station in results)
                {
                    Console.WriteLine($"{station.name}: {station.latitude} lat {station.longitude} long"); 
                }*/

                // utilize Loader for JsonConvert now, saves a few lines of code
                // Loader loader = JsonConvert.DeserializeObject<Loader>(result); // replace with generic Loader
                Loader<Station> loader = JsonConvert.DeserializeObject<Loader<Station>>(result);
                Console.WriteLine(loader.Metadata.ResultSet.Limit + " Stations Loaded");
                foreach(Station station in loader.Results)
                {
                    Console.WriteLine($"{station.Id}:\t{station.Name}");
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            finally
            {
                AreRequestsCompleted = true;
            }
        }
    }
}
