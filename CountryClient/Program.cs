using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Countries.Lib.CountryInfo;

namespace CountryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CountryInfoServiceSoapTypeClient client =
                new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            tCountryCodeAndName[] countries = client.ListOfCountryNamesByName();
            Console.WriteLine($"{countries.Length} countries found:");
            foreach(var country in countries)
            {
                Console.WriteLine($"{country.sISOCode}: \t{country.sName}");
            }
            // Press any key to close cmd line window
            Console.ReadLine();
        }
    }
}

