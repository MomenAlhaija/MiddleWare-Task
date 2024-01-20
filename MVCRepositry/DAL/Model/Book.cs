using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthoId { get; set; }    

        public virtual Autho Autho { get; set; }    
    }
}
