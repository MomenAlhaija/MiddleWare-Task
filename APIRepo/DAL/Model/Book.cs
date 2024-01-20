using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = null!;

        public int AuthoId { get; set; }

        public virtual Autho Autho { get; set; } = null!;
    }
}
