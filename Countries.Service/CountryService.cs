using Countries.Lib.CountryInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Service
{
    // internal class, interesting
    internal class CountryService : ICountryService
    {
        public tCountryCodeAndName[] GetCountries()
        {
            CountryInfoServiceSoapTypeClient client =
                new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            return client.ListOfCountryNamesByName();
        }

        public tContinent[] GetContinents()
        {
            CountryInfoServiceSoapTypeClient client =
                new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            return client.ListOfContinentsByName();
        }

        public tCurrency[] GetCurrencies()
        {
            CountryInfoServiceSoapTypeClient client =
                new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            return client.ListOfCurrenciesByName();
        }
    }
}
