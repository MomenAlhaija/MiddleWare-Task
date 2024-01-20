using Microsoft.AspNetCore.Mvc;

namespace Secondcore.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        [Area("Employee")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
