using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReviewAPI.Data;
using ReviewAPI.DTO;
using ReviewAPI.Model;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGenreAsync()
        {
            var Genres =await _context.Genres.OrderBy(g=>g.Name).ToListAsync(); 
            return Ok(Genres);
        }
        [HttpPost]
        public async Task<IActionResult> AddGenreAsync(GenreDTO genre)
        {
            var Genre=new Genre();
            Genre.Name = genre.Name;
            await _context.Genres.AddAsync(Genre);
            _context.SaveChanges();
            return Ok(Genre);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync(int Id, [FromBody] GenreDTO genreDTO)
        {
            var genre=await _context.Genres.FirstOrDefaultAsync(g=>g.Id == Id);
            if(genre == null)
            {
                return NotFound($"Not found Genre with Id {Id}");
            }
            genre.Name = genreDTO.Name;
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return Ok(genre);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id);
            if (genre == null)
            {
                return NotFound($"Not found Genre with Id {Id}");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return Ok();
        }
    }
}
