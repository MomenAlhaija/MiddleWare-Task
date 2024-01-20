using C__Advance.Indexer.Models;
using C__Advance.Math;
using System.Collections.Generic;
using System.Data;
using System.Text;
List<Person> people = new List<Person>();
#region addPersons
people.Add(new Person()
{
    PersonId = 1,
    PersonName = "Momen",
    Age = 24,
    Gender = "Male"
});

people.Add(new Person()
{
    PersonId = 2,
    PersonName = "Ahmad",
    Age = 30,
    Gender = "Male"
}); people.Add(new Person()
{
    PersonId = 3,
    PersonName = "Omar",
    Age = 42,
    Gender = "Male"
}); people.Add(new Person()
{
    PersonId = 4,
    PersonName = "Nedaa",
    Age = 54,
    Gender = "Female"
}); people.Add(new Person()
{
    PersonId = 5,
    PersonName = "Mohammad",
    Age = 18,
    Gender = "Male"
});
#endregion
Company C=new Company();
C[6] = "Saleh";
Console.WriteLine(C[6]);
C["Ahmad"] = 10;
Console.WriteLine(C["Ahmad"]);
