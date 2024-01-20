using Microsoft.AspNetCore.Mvc;

namespace ReviewSomeCoreTopic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }


}
