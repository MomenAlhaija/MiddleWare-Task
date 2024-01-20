using APIMovies2.Data;
using APIMovies2.DTO;
using APIMovies2.Model;
using APIMovies2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMovies2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenersController : ControllerBase
    {
        private readonly IGenersService _generaservice;
        private readonly ILogger<GenersController> _logger;
        public GenersController(IGenersService generaservice, ILogger<GenersController> logger)
        {
            _generaservice = generaservice;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> AllGener()
        {
         var geners=  await _generaservice.AllGener();
         return Ok(geners);
        }
        
        [HttpPost]
        public async Task<IActionResult> newGeners(GenreDTO dto)
        {
            var genera = new Genre {
                Name = dto.Name,
                Description = dto.Description}; 
            await _generaservice.newGeners(genera);
            return Ok(genera);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id,GenreDTO dto)
        {   
            var Gen=await _generaservice.SingleGenre(id);
            if(Gen==null)
            {
                _logger.LogWarning($"The Genra not found where id={id}");
                return NotFound($"Not found the Genera ID:{id}");
            }
            Gen.Name = dto.Name;
            Gen.Description = dto.Description;  
            _generaservice.Edit(Gen);
            return Ok(Gen);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var gen=await _generaservice.SingleGenre(id);

            if (gen == null)
            {
                return NotFound($"Not found the Genera ID:{id}");
            }
            else
            {
               _generaservice.delete(gen);  
                return Ok();
            }
        }

    }
}
