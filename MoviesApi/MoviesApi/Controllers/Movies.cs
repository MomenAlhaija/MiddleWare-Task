using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTO;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class Movies : ControllerBase
    {
        private new List<string> _allowExtension=new List<string> { ".JPG", ".BNG" };
        private long _MaxAllowLebgth = 1048576;
        private readonly ApplicationDbContext _db;
        public Movies(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync() { 
        
            var Movies=await _db.Movies.OrderByDescending(P=>P.Rate ).Include(g=>g.Genre).ToListAsync();
            return Ok(Movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {

            var Movie = await _db.Movies.Include(g=>g.Genre).SingleOrDefaultAsync(p=>p.Id==id);
            if (Movie == null)
            {
                return NotFound("Not Found the Movie");
            }

            return Ok(Movie);
        }
        [HttpGet("GetMovieByGenreId")]
        public async Task<IActionResult> GetMovieByGenreId(int id) {

            var Movies = await _db.Movies.Include(g => g.Genre).Where(p=>p.GenreId==id).ToListAsync();
            if(Movies == null)
            {
                return NotFound("Not Found The Movies include this Genere");
            }
            return Ok(Movies);

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] MoveDto dto)
        {
            if (!_allowExtension.Contains(Path.GetExtension(dto.Poster.FileName).ToUpper()))
            {
                return BadRequest("Only Png and Jpg Images Allowed");
            }
            if (dto.Poster.Length > _MaxAllowLebgth)
            {
                return BadRequest("The Max Length Allowed is 1 MB");
            }
            var isvalidGenerc = await _db.Genres.AnyAsync(P => P.Id == dto.Id);
            if(isvalidGenerc==null)
            {
                return BadRequest("Invalid Geners ID");
            }
            using var datasream=new MemoryStream();
            await dto.Poster.CopyToAsync(datasream);
            var movie = new Movie();

            movie.GenreId = dto.GenreId;
            movie.Title = dto.Title;
            movie.Poster = datasream.ToArray();
            movie.Rate = dto.Rate;
            movie.StoreLine = dto.StoreLine;
            movie.Year = dto.Year;
            
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return Ok();
           
        }
        [HttpPut("{id}")]
        public async  Task<IActionResult> Updateasync(int id, [FromForm] MoveDto dto)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound("Not Found The Movie");
            }
            if (dto.Poster != null)
            {
                if (!_allowExtension.Contains(Path.GetExtension(dto.Poster.FileName).ToUpper()))
                {
                    return BadRequest("Only Png and Jpg Images Allowed");
                }
                if (dto.Poster.Length > _MaxAllowLebgth)
                {
                    return BadRequest("The Max Length Allowed is 1 MB");

                }
                using var datasream = new MemoryStream();
                await dto.Poster.CopyToAsync(datasream);
                movie.Poster = datasream.ToArray();
            }


            movie.GenreId = dto.GenreId;
            movie.Title = dto.Title;
            movie.Rate = dto.Rate;
            movie.StoreLine = dto.StoreLine;
            movie.Year = dto.Year;
            _db.SaveChanges();

            return Ok(movie);
        }
        [HttpDelete("{id}")]
        public  async  Task<IActionResult> DeleteAsync(int id)
        {
            var Movie=_db.Movies.FirstOrDefault(x => x.Id == id);

            if(Movie == null)
            {
                return NotFound("Not Found The Movie");
            }
            _db.Movies.Remove(Movie);
            _db.SaveChanges();
            return Ok();
        }         

    }
}
