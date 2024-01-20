using Entites;
using ServiceContarct;
using ServiceContarct.DTO;
using Services;
using Xunit;
namespace CRUDExample
{
    public class CoutriesServiceTest 
    {
        private readonly ICountryService _countryService;
        public CoutriesServiceTest()
        {
            _countryService = new CountryService();
        }
        /// <summary>
        /// Test if Pass Null  should throw Argument Null Exception 
        /// </summary>
        [Fact]
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest country = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
            });
        }
        /// <summary>
        /// check if Country Name is Null should throw Argument Null Exception 
        /// </summary>
        [Fact]
        public void AddCountry_CountryNameisNull()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name=null};
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
            });
        }
        /// <summary>
        /// check if Country NAme is deplicate should throw Argument Exeption
        /// </summary>
        [Fact]
       
        public void AddCountry_DuplicateCountryName()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name = "Irbid" };
            CountryAddRequest country2 = new CountryAddRequest() { Name = "Irbid" };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countryService.AddCountry(country);
                _countryService.AddCountry(country2);
            });
        }
        /// <summary>
        /// when Add Country should is found in the list countries
        /// </summary>
        [Fact]
        public void AddCountry_ProperCountryetailes()
        {
            //Arrange
            CountryAddRequest country = new CountryAddRequest() { Name = "USA" };
             
            //Act
            
            CountryResponse countryResponse = _countryService.AddCountry(country);

            //Assert

            Assert.True(countryResponse.Id != Guid.Empty);
        }
    }
   
}
