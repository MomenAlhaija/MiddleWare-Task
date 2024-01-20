using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using WebApplication6.DbComtext;
using WebApplication6.ViewModel;
using WebApplication6.Data.Model;
namespace WebApplication6.Service
{
   
    public class AuthorService
    {
        private readonly AppdbContect _db;
        public AuthorService(AppdbContect db) {
            _db= db;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _db.Authors.Add(_author);
            _db.SaveChanges();
         
        }
        public  List<AuthorsWithBooksVM> getAllAuthors()
        {
            var _authors = _db.Authors.Select(auth => new AuthorsWithBooksVM()
            {


                FullName = auth.FullName,
                BooksTotles = auth.Book_Author.Select(n => n.Book.Title).ToList()

            }).ToList() ;
            return _authors ;   
        } 
    }
}
