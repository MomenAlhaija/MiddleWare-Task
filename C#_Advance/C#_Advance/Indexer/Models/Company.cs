using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Advance.Indexer.Models
{
    internal class Company
    {
        private List<Person> people;
        public Company()
        {
            people = new List<Person>();
            #region addPersons
            people.Add(new Person()
            {
                PersonId = 6,
                PersonName = "Momen",
                Age = 24,
                Gender = "Male"
            });

            people.Add(new Person()
            {
                PersonId = 7,
                PersonName = "Ahmad",
                Age = 30,
                Gender = "Male"
            }); people.Add(new Person()
            {
                PersonId = 8,
                PersonName = "Omar",
                Age = 42,
                Gender = "Male"
            }); people.Add(new Person()
            {
                PersonId = 9,
                PersonName = "Nedaa",
                Age = 54,
                Gender = "Female"
            }); people.Add(new Person()
            {
                PersonId = 10,
                PersonName = "Mohammad",
                Age = 18,
                Gender = "Male"
            });
            #endregion
        }
        public string this[int PersonId]
        {
            get {

                return people.FirstOrDefault(PID => PID.PersonId == PersonId).PersonName;
            }
            set
            {
                people.FirstOrDefault(PN => PN.PersonId == PersonId).PersonName=value;  
            }
        }
        public int this[string PersonName]
        {
            get { return people.FirstOrDefault(PN => PN.PersonName == PersonName).PersonId; }
            set { people.FirstOrDefault(PN => PN.PersonName == PersonName).PersonId = value; }
        }

    }
    }
