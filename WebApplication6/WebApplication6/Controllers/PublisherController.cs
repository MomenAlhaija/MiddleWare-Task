using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using WebApplication6.Service;
using WebApplication6.ViewModel;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisher;
        public PublisherController(PublisherService publisher)
        {
            _publisher = publisher;   
        }
        [HttpPost("Add-Publisher")]
        public async Task<IActionResult> AddPublisher(PublisherVM newPublisher)
        {
            _publisher.AddPublisher(newPublisher);
            return Ok();
        }
        [HttpGet("GetAll_puplisher_withData")]
        public IActionResult GetPublisher()
        {
            throw new Exception("This is an Exeption that will be handled by middleWare");
            var puplishers=_publisher.GitAll_Publisher_withData();
            return Ok(puplishers);
        }
        [HttpDelete("Delete_Puplisher_byID")]
        public IActionResult DeletePublisher(int id) {
            try
            {
            //    int x = 1;
            //    int x2 = 0;
            //    int result = x/x2;
                _publisher.DeletePublisher(id);
                return Ok();
            }
           
            catch(ArithmeticException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }
            finally
            {
                string stopHere = "";
            }
        } 
    }


}
