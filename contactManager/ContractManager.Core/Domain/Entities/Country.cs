using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManager.Core.Domain.Entities
{
    public class Country
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
