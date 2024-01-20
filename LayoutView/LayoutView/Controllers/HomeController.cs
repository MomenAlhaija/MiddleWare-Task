using LayoutView.Models;
using Microsoft.AspNetCore.Mvc;

namespace LayoutView.Controllers
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
