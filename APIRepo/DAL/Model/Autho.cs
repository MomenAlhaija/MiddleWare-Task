using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    [Table("Authos")]
    public class Autho
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;


    }
}
