using Countries.Lib.CountryInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Countries.Web.Controllers
{
    public class CountryController : ApiController 
    {
        public async Task<IHttpActionResult> Get()
        {
            // Async 
            CountryInfoServiceSoapTypeClient client =
                new CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap12");
            var response = await client.ListOfCountryNamesByNameAsync();
            tCountryCodeAndName[] countries = response.Body.ListOfCountryNamesByNameResult;
            return Json(countries);
        }
    }
}