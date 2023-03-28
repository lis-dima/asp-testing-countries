namespace asp_testing_countries.Services.Country
{
    public interface ICountryRepository
    {
        CreateCountryResponse CreateCountry(CreateCountryRequest request);
        List<Country> GetAll();
    }
}
