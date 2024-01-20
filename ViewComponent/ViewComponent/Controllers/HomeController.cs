using Microsoft.AspNetCore.Mvc;

namespace ViewComponent.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
