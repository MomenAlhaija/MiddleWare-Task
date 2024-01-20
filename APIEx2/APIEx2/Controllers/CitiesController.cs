using APIEx2.Data;
using APIEx2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace APIEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CitiesController(ApplicationDbContext db)
        {
            _db= db;    
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            if(_db.Cities==null) 
                return NotFound();
            return await _db.Cities.OrderBy(C=>C.CityName).ToListAsync();
        }
        [HttpGet("{cityId}")]

        public async Task<IActionResult> GetCityById(Guid cityId)
        {
            City? city = await _db.Cities.FindAsync(cityId);
            if(city==null) return NotFound();   
            return Ok(city);
        }
        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] City city)
        {
            if(city==null) return BadRequest();
            await _db.Cities.AddAsync(city);
            _db.SaveChanges();
            return Ok(city);
        }
        [HttpPut("{CityId}")] 
        public IActionResult EditCity( Guid CityId, City city)
        {
            if (CityId != city.CityId)
                return Problem(detail: "Invalied CityId", statusCode: 400, title: "Edit City");
            _db.Entry(city).State=EntityState.Modified;
            _db.SaveChanges();
            return Ok(city);
        }
        [HttpDelete("{CityId}")]
        public async Task<IActionResult> Remove(Guid CityId)
        {

            City? city=await _db.Cities.FindAsync(CityId);
            if(city==null) return NotFound();
            _db.Cities.Remove(city);
            _db.SaveChanges();
            return Ok();
        }

    }
}
