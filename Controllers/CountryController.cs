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

            if (request.Name is null)
                throw new ArgumentNullException(nameof(CreateCountryRequest.Name));

            if(request.Name == "")
                throw new Exception("Country name not allowed");

            if (GetCountryByName(request.Name) != null)
                throw new Exception("This country already exist");

            return countryRepository.CreateCountry(request);
        }

        [HttpGet]
        public Country? GetCountryByName(string countryName)
        {
            return countryRepository
                .GetAll()
                .Where(c => c.Name == countryName)
                .FirstOrDefault();
        }

    }
}
