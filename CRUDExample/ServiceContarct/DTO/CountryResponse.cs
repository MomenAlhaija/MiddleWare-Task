using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
namespace ServiceContarct.DTO
{
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse { Id = country.Id, Name = country.Name }; 
        }
    }
}
