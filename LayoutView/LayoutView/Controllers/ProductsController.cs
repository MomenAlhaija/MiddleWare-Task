using Microsoft.AspNetCore.Mvc;

namespace LayoutView.Controllers
{
    public class ProductsController : Controller
    {
        [Route("Shop")]
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult SingleProduct()
        {
            return View();
        }
    }
}
