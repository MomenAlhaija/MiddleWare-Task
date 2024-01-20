namespace WebApplication6.ViewModel
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class Puplisher_withBooks_andAutors
    {
        public string Name { get; set; }
        public List<BookWithNamesVM> BookAuthors { get; set; }

    }
}
