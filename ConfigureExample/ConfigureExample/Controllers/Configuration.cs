using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ConfigureExample.Controllers
{
    public class Configuration : Controller
    {
        private readonly WeatherAPiOption _options;
        public Configuration(IOptions<WeatherAPiOption> options)
        {
           _options = options.Value;  
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.ClientId=_options.ClientId;
            ViewBag.ClientSecret= _options.ClientSecret;
            return View();
             
        }
    }
}
