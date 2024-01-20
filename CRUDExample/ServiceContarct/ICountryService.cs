using Entites;
using ServiceContarct.DTO;
namespace ServiceContarct
{
    public interface ICountryService
    {
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);
    }
}