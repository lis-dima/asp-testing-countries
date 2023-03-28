using asp_testing_countries.Services.Country;
using Microsoft.AspNetCore.Mvc;

namespace asp_testing_countries.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpPost]
        public CreateCountryResponse CreateCountry(CreateCountryRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(CreateCountryRequest));
            return countryRepository.CreateCountry(request);
        }

    }
}
