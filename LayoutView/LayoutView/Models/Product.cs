namespace LayoutView.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ProductImage {get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Voite { get; set;}
        public int? Previews { get; set; }

    }
}
