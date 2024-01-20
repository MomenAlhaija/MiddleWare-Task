using Core.Repositry;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRepo.Controllers
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_repositry.GetByID(id));
        }
    }
}
