using Core.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Model;
namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoController : ControllerBase
    {
        private readonly IRepositry<Autho> _repositry;
        public AuthoController(IRepositry<Autho> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]
        public IActionResult GetById(int id) { 
         
           return Ok(_repositry.GetByID(id));
        }
        
    }
}
