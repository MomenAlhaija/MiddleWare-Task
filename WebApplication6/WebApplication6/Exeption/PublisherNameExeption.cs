namespace WebApplication6.Exeption
{
    public class PublisherNameExeption:Exception
    {
        public string PublisherName { get; set; }
        public PublisherNameExeption()
        {
            
        }
        public PublisherNameExeption(string Message):base(Message)
        {
            
        }
        public PublisherNameExeption(string Message,Exception inner):base(Message, inner) 
        {
            
        }
        public PublisherNameExeption(string Message,string puplisherNme):base(Message)
        {
            PublisherName = puplisherNme;
        }
    }
}
