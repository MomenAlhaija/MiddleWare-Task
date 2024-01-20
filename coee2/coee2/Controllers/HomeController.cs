using coee2.CustomModelBinding;
using coee2.Models;
using Microsoft.AspNetCore.Mvc;

namespace coee2.Controllers
{
    public class HomeController : Controller
    {
        [Route("Register")]
        public  IActionResult Index([FromBody]  Person person)
        {
            if (ModelState.IsValid)
            {
              
                return Content($"{person}");
            }
            else
            {
                string errors=string.Join("\n"
                    ,ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage));
                return BadRequest(errors);
            }
        } 
    }
}
