using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class PhoneBook
    {
        private List<Person> persons;
        private List<Phone> phones;

        public PhoneBook()
        {
            persons = new List<Person>()
            {
              new Person {
                  ID = 0, Name = "Adam", Organization = "ZUS",
                  Phones=new List<Phone>{
                      new Phone {ID=0, Number="121212"}
                  }
              },
              new Person {
                  ID = 1, Name = "Alicja", Organization = "ZUS",
                  Phones=new List<Phone>{
                      new Phone {ID=1, Number="33121212"}
                  }
              },
              new Person {
                  ID = 2, Name = "Dagmara", Organization = "ZUS",
                  Phones=new List<Phone>{
                      new Phone {ID=2, Number="11142"},
                      new Phone {ID=3, Number="222333"}
                  }
              }
            };

        }

        public List<Person> GetPersons()
        {
            return persons.Select(p => (Person) p.Clone()).ToList();
        }

        public Person GetPersonWithID(int id)
        {
            return (Person) persons[id].Clone();
        }

        public Person AddNewPerson(Person person) { 
            return null;
        }

        public Person UpdatePersonWithID(int id, Person person)
        {
            return null;
        }

        public Person DeletePerson(int id)
        {
            return null;
        }

    }
}