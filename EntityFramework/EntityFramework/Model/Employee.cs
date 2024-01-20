using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Model
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }

        public int DepId { get; set; }
        [ForeignKey("DepId")]
        public virtual Dep Department { get; set; }
    }

}
