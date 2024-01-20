using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        public IActionResult Index()
        {
            List<Person> persons = new List<Person>
            {
                new Person{Name="Momen",DateOfBirth=Convert.ToDateTime("1999-10-27")},
                new Person{Name="Ahmad",DateOfBirth=Convert.ToDateTime("2004-4-10")},
                new Person{Name="Saif",DateOfBirth=Convert.ToDateTime("1992-3-10")},
                new Person{Name="Saleh",DateOfBirth=Convert.ToDateTime("1996-2-10")},
                new Person{Name="Nedaa",DateOfBirth=Convert.ToDateTime("1995-7-10")},
                new Person{Name="Sara",DateOfBirth=Convert.ToDateTime("1994-2-10")},
                new Person{Name="Jana",DateOfBirth=Convert.ToDateTime("1997-1-10")}

            };
            return View("Index",persons);
        }
        [Route("Person-detailes/{Name}")]
        public IActionResult Detailes(string? Name)
        {
            if(Name == null)
                return Content("Person Name Can't be Null");
            List<Person> persons = new List<Person>
            {
                new Person{Name="Momen",DateOfBirth=Convert.ToDateTime("1999-10-27")},
                new Person{Name="Ahmad",DateOfBirth=Convert.ToDateTime("2004-4-10")},
                new Person{Name="Saif",DateOfBirth=Convert.ToDateTime("1992-3-10")},
                new Person{Name="Saleh",DateOfBirth=Convert.ToDateTime("1996-2-10")},
                new Person{Name="Nedaa",DateOfBirth=Convert.ToDateTime("1995-7-10")},
                new Person{Name="Sara",DateOfBirth=Convert.ToDateTime("1994-2-10")},
                new Person{Name="Jana",DateOfBirth=Convert.ToDateTime("1997-1-10")}

            };
            Person person=persons.FirstOrDefault(x => x.Name == Name);
            if (person == null)
                return Content($"Not Found Person Name is:{Name}");
            return View(person);

        }
        [Route("Person-With-Product")]
        public IActionResult PersonandProduct()
        {
            Person person = new Person() { Name="Momen",DateOfBirth=Convert.ToDateTime("1999-10-27")};
            Product product = new Product() { ProductId=2,ProductName="Phone"};
            PersonAndProduct personAndProduct = new PersonAndProduct() { person = person, product = product };
            return View("PersonandProduct", personAndProduct);
        }
    }
}
    