using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public float Price { get; set; } 
        public DateTime Date= DateTime.Now; 

    }
}
