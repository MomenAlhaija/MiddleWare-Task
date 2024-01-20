// See https://aka.ms/new-console-template for more information
using EntityFramework.Data;
using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
Employee employee = new Employee()
{
    name = "Momen",
    DepId=2
};
var _contex = new AppDbContext();
_contex.Add(employee);
_contex.SaveChanges();


