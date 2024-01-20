namespace Secondcore.Models
{
    public class Item
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        
        public Category? Category { get; set; }   


    }
}
