using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ReviewAPI.Data;
using ReviewAPI.DTO;
using ReviewAPI.Model;
using System.Dynamic;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private new List<string> _allowextension=new List<string> {".jpg",".png" };
        private long _maxAllowedSize = 1048576;
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovieAsync()
        {
            var movies=await _context.Movies.Include(g => g.Genre).ToListAsync();
            return Ok(movies);
        }
        [HttpGet("{Id")]
        public async Task<IActionResult> GetMovieByIdAsync(int Id)
        {
            var movie=await _context.Movies.Include(g=>g.Genre).FirstOrDefaultAsync(m=>m.Id==Id);
            if(movie==null) return NotFound();
            return Ok(movie);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetGenreById(int Id)
        {
            var genre=await _context.Genres.FirstOrDefaultAsync(g=>g.Id==Id);
            if(genre==null) return NotFound();
            return Ok(genre);
        }
        [HttpPost]
        public async Task<IActionResult> AddMovieAsync([FromForm] MovieDTO movieDTO)
        {
           
            if (!_allowextension.Contains(Path.GetExtension(movieDTO.Poster.FileName).ToLower()))
            {
                return BadRequest("Only PNG and JPG Image Allowed");
            }
            if(movieDTO.Poster.Length>_maxAllowedSize)
            {
                return BadRequest("Maxe Image Size is 1MB only");

            }
            using var datastream = new MemoryStream();
            await movieDTO.Poster.CopyToAsync(datastream);
            if (! await _context.Genres.AnyAsync(g => g.Id == movieDTO.GenreId))
            {
                return BadRequest($"Not found Genre With Id: {movieDTO.GenreId}");
            }
            var Movie = new Movie
            {
                GenreId = movieDTO.GenreId,
                Title = movieDTO.Title,
                Poster = datastream.ToArray(),
                Rate = movieDTO.Rate,
                Storline = movieDTO.Storline,
                Year = movieDTO.Year
            };
            await _context.Movies.AddAsync(Movie);
            _context.SaveChanges();
            return Ok(Movie);
        }
    }
}
