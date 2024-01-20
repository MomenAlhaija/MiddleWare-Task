using Microsoft.AspNetCore.Mvc;
namespace ViewsComponentsProject.Compnents
{
    [ViewComponent]
    public class GridViewCompnent
    {
        public async Task<IViewComponentResult>  InvokeAsync()
        {
            return View();
        }   
    }
}
