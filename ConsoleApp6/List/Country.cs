using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    internal class Country
    {
        public string IsoCode { get;set; }
        public string Name { get;set; }
        public override string ToString()
        {
            return $"{Name}({IsoCode})";
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash=hash*397+IsoCode.GetHashCode();
                hash = hash * 397 + Name.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
          var Country=obj as Country;
            if(Country is null) 
                return false;
            return this.Name.Equals(Country.Name, StringComparison.OrdinalIgnoreCase)
                && this.IsoCode.Equals(Country.IsoCode, StringComparison.OrdinalIgnoreCase);
        }
    }
}
