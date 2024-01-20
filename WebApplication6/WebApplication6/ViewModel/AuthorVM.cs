using WebApplication6.Model.Model;

namespace WebApplication6.ViewModel
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }
    public class AuthorsWithBooksVM
    {
        public List<string> BooksTotles { get; set; }
        public string FullName { get; set; }
    }

}
