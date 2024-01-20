using Microsoft.EntityFrameworkCore;
using WebApplication6.Data.Model;
using WebApplication6.DbComtext;
using WebApplication6.Model.Model;
using WebApplication6.ViewModel;

namespace WebApplication6.Service
{
    public class BookService
    {
        private readonly AppdbContect _db;
        
        public BookService(AppdbContect db)
        {
            _db = db;
        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rate = book.isRead ? book.Rate.Value : null,
                Genra = book.Genra,
                coverUrl = book.coverUrl,
                DateAdd = book.DateAdd,
                Publisherid = book.Publisherid,

            };
            _db.Books.Add(_book);
            _db.SaveChanges();

            foreach(var id in book.AuthorsIds)
            {
                var book_author = new Book_author
                {
                    BookId = _book.Id,
                    AuthorId = id

                };
                _db.Book_Authors.Add(book_author);
                _db.SaveChanges() ;
            } 

        }
        public  List<BookWithNamesVM> GetAllBooks() {
            var books =  _db.Books.Select(book => (new BookWithNamesVM() {

                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rate = book.isRead ? book.Rate.Value : null,
                Genra = book.Genra,
                coverUrl = book.coverUrl,
                DateAdd = book.DateAdd,
                PublisherName = book.publisher.Name,
                AuthorsNames=_db.Book_Authors.Select(n=>n.Author.FullName).ToList(),
                

            })).ToList();
            return books;
              
         }

    }
}  
