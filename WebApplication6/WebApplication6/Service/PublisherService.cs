using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebApplication6.Data.Model;
using WebApplication6.DbComtext;
using WebApplication6.Exeption;
using WebApplication6.ViewModel;

namespace WebApplication6.Service
{
    public class PublisherService
    {
        private AppdbContect _db;
        public PublisherService(AppdbContect db)
        {
            _db = db;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            if (StringStartWithNumber(publisher.Name))
                throw new PublisherNameExeption("Name Start with Number", publisher.Name);

            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _db.publishers.Add(_publisher);
            _db.SaveChanges();

        }

        public List<Puplisher_withBooks_andAutors> GitAll_Publisher_withData() {

            var _puisherwithData = _db.publishers.Select(pup => new Puplisher_withBooks_andAutors()
            {
                Name = pup.Name,
                BookAuthors = pup.Books.Select(pup => new BookWithNamesVM()
                {
                    Title = pup.Title,
                    AuthorsNames = _db.Book_Authors.Select(pup => pup.Author.FullName).ToList()
                }).ToList(),

            }).ToList() ;

            return _puisherwithData;
        }

        internal void DeletePublisher(int id)
        {
            var pup = _db.publishers.FirstOrDefault(p=>p.Id==id);
            if (pup == null)
                Console.WriteLine("Not found the puplisher");
            else
            {
                _db.publishers.Remove(pup);
                _db.SaveChanges();
            }
        }
        private bool StringStartWithNumber(string Name) => Regex.IsMatch(Name, @"^\d");
           
        
    }
}
