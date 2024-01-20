using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication6.Model.Model;

namespace WebApplication6.Data.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }   

    }
    
}
