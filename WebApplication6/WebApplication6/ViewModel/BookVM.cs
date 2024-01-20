using WebApplication6.Data.Model;

namespace WebApplication6.ViewModel
{
    public class BookVM
    {
        public string Title { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string? coverUrl { get; set; }
        public int? Rate { get; set; }
        public string Genra { get; set; }

        public int Publisherid { get; set; }
        public List<int> AuthorsIds { get; set; } = null!;


    }
    public class BookWithNamesVM
    {
        public string Title { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string? coverUrl { get; set; }
        public int? Rate { get; set; }
        public string Genra { get; set; }

        public string PublisherName { get; set; }
        public List<String> AuthorsNames { get; set; } = null!;


    }
}
