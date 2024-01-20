using WebApplication6.Model.Model;

namespace WebApplication6.Data.Model
{
    public class Author
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Book_AuthorId { get; set; }

        public List<Book_author> Book_Author { get; set; }

    }

}
