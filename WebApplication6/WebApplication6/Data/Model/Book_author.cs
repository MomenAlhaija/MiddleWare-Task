using WebApplication6.Model.Model;

namespace WebApplication6.Data.Model
{
    public class Book_author
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
