using APIMovies2.Data;
using APIMovies2.DTO;
using APIMovies2.Model;
using APIMovies2.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APIMovies2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly IMovieService _MovieService;
        private readonly IGenersService _GenreService;

        private new List<string> _allowExtension = new List<string> { ".jpg", ".png" };
        private long _MaxAllowedPoster =10048576;

        public MoviesController(IMovieService MovieService,IGenersService GenreService,IMapper Mapper)
        {
            _MovieService= MovieService;
            _GenreService= GenreService;
            _Mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AllMovies()
        {
            var movies = await _MovieService.AllMovies();
            var data = _Mapper.Map<IEnumerable<MovieDtoDetailes>>(movies);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] MoviesDTO dto)
        {
            var isvalied = await _GenreService.isValiedGenre(dto.GenreId);
            if (!isvalied)
                return BadRequest("Not found the Genra");
            if (dto.Poster.Length > _MaxAllowedPoster)
                return BadRequest("Max Size is 1MB");
            if (!await _GenreService.isValiedGenre(dto.GenreId))
                return NotFound($"Not Found the Genra by ID:{dto.GenreId}");
            using var dataStream = new MemoryStream();
            await dto.Poster.CopyToAsync(dataStream);
            var movie = _Mapper.Map<Movie>(dto);
            movie.Poster = dataStream.ToArray();
            await _MovieService.Add(movie);
            return Ok(movie);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _MovieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound("Not found the Movie");
            }
            var data = _Mapper.Map<MovieDtoDetailes>(movie);
            return Ok(data);
        }
        [HttpGet("GetMovieByGenraId")]
        public async Task<IActionResult> GetMovieByGenraId(int Genraid)
        {
            var movies = await _MovieService.AllMovies(Genraid);
            var data = _Mapper.Map<IEnumerable<MovieDtoDetailes>>(movies);
            return Ok(data);
        }
     

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _MovieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _MovieService.Delete(movie);
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] MoviesDTO dto)
        {
            var isvalied = await _GenreService.isValiedGenre(dto.GenreId);
            if (!isvalied)
            {
                return BadRequest("Not found the Genra");
            }
            var movie = await _MovieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            movie.Name = dto.Name;
            movie.StateLine = dto.StateLine;
            movie.Rate = dto.Rate;
            movie.Year = dto.Year;
            movie.GenreId = dto.GenreId;
            if (dto.Poster != null)
            {
                if (!_allowExtension.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Onlu PNG and JPG Images allowed");

                else if (dto.Poster.Length > _MaxAllowedPoster)
                    return BadRequest("Max Size is 1MB");

                else
                {
                    using var dataStream = new MemoryStream();
                    await dto.Poster.CopyToAsync(dataStream);
                    movie.Poster = dataStream.ToArray();
                }
            }
            await _MovieService.Edit(movie);
            return Ok();
        }

    }
}
