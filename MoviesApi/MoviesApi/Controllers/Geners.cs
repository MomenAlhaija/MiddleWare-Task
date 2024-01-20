using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesApi.DTO;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Geners : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public Geners(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var geners = await _db.Genres.OrderBy(p => p.Name).ToListAsync();
            return Ok(geners);
        }
        [HttpPost]
        public async Task<IActionResult> GreateAsync(CreateGenresDtocs dto)
        {
            var genre = new Genre();
            genre.Name = dto.Name;
            genre.Description = dto.Description;
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return Ok(genre);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdaeAsync(int id, CreateGenresDtocs dto)
        {
            var genre = _db.Genres.Find(id);
            if(genre == null)
            {
                return NotFound($"Not Found Genera with Id: {id}");  
            }
            genre.Name=dto.Name;
            genre.Description=dto.Description;
            _db.SaveChanges();
            return Ok(genre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            var genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound($"Not Found Genera with Id: {id}");
            }
            _db.Genres.Remove(genre);

            _db.SaveChanges();
            return Ok();

        }

    }
}
