using Core.Repositry;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositry<Book> _repositry;
        public BooksController(IRepositry<Book> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet("GetById")]
        public ActionResult<Book> GetById(int id)
        {

            return Ok(_repositry.GetByID(id));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var test = _repositry.GetAll();

            return Ok(test.ToList());
        }

    }
}
