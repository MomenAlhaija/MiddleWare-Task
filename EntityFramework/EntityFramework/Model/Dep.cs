using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Model
{
    public class Dep
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
