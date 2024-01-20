using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using Services;
namespace DependanyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(ICitiesService citiesService, IWebHostEnvironment webHost)
        {
            _citiesService = citiesService;
            _webHost = webHost;
   
        }
        [Route("/")]
        public IActionResult Index()
        {
           ViewBag.CurrentEnvironment= _webHost.EnvironmentName;
            return View(_citiesService.GetCities());
        }
        [Route("About")]
        public IActionResult About() {
            
            return View();
        }

    }
}
