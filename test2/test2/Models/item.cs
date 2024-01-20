using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models
{
    public class item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DisplayName("The Price")]
        [Range(5,10000,ErrorMessage ="The Price should between 5 and 10000")]
        public decimal price { get; set; }

        public DateTime Date { get; set; }= DateTime.Now;
        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
