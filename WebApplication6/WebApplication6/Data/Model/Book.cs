using WebApplication6.Data.Model;

namespace WebApplication6.Model.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string? coverUrl { get; set; }
        public int? Rate { get; set; }
        public string Genra { get; set;}

        public int Publisherid { get; set; }
        public Publisher publisher { get; set; }

    }
}
