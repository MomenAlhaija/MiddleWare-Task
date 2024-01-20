using Microsoft.AspNetCore.Mvc;
using ReviewSomeCoreTopic.Models;

namespace ReviewSomeCoreTopic.Controllers
{
   
    public class testController : Controller
    {
        [Route("test/Index")]
        public ContentResult Index()
        {
            ContentResult result = new ContentResult()
            {
                Content = "thank you",
                ContentType = "text/html"
            };
            return result;
        }
        [Route("test/JsonReturn")]

        public JsonResult JsonReturn()
        {
           Person person = new Person()
           {
               PersonId=Guid.NewGuid(),
               PersonName="Momen",
               Email="haija@gmail.com"
           };
            return new JsonResult(person);
        }
        [Route("test/fileReturn")]

        public PhysicalFileResult fileReturn() {

            return new PhysicalFileResult("C:\\Users\\User\\Downloads\\Mercury.jpg", "application/jpg");
        }
        [Route("test/FileContent")]
        public FileContentResult FileContent()
        {
            byte[] contentt = System.IO.File.ReadAllBytes("C:\\Users\\User\\Downloads\\Mercury.jpg");
            return new FileContentResult(contentt, "application/png");
        }



    }
}
