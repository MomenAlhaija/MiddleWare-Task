using Core.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Model;
namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxController : ControllerBase
    {
        private readonly IRepositry<Book> _repositry;
        public BoxController(IRepositry<Book> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {

            return Ok(_repositry.GetByID(id));
        }
    }

}
