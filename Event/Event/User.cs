using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    public class User
    {
        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }

        private string lastName;    
        public string LastName { get { return lastName; } set { lastName = value; } }

        private string email;
        public string Email { get { return email; } set { email = value; } }
        public User(string firstName,string lastName,string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
