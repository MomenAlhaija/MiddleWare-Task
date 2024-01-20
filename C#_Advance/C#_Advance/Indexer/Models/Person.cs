using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Advance.Indexer.Models
{
    internal class Person
    {
        

        [Required]
        public int PersonId { get; set; }

        public string? PersonName { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }
    }
}
