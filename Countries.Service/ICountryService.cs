using Countries.Lib.CountryInfo;
using System.ServiceModel;

namespace Countries.Service
{
    // Contract syntax, aka Attributes
    [ServiceContract]
    internal interface ICountryService
    {
        [OperationContract]
        tContinent[] GetContinents();
        [OperationContract]
        tCountryCodeAndName[] GetCountries();
        [OperationContract]
        tCurrency[] GetCurrencies();
    }
}