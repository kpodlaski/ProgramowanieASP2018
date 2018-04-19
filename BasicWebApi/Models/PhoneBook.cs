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
            phones = new List<Phone>() {
                new Phone {ID=0, Number="121212"},
                new Phone {ID=1, Number="33121212"},
                new Phone {ID=2, Number="11142"},
                new Phone {ID=3, Number="222333"}
            };

            persons = new List<Person>()
            {
              new Person {
                  ID = 0, Name = "Adam", Organization = "ZUS",
                  Phones=new List<Phone>{
                      phones[0]
                  }
              },
              new Person {
                  ID = 1, Name = "Alicja", Organization = "ZUS",
                  Phones=new List<Phone>{
                      phones[1]
                  }
              },
              new Person {
                  ID = 2, Name = "Dagmara", Organization = "ZUS",
                  Phones=new List<Phone>{
                      phones[2],
                      phones[3]
                  }
              }
            };

        }

        public List<Person> GetPersons()
        {
            lock (persons)
            {
                return persons.Select(p => (Person)p.Clone()).ToList();
            }
        }

        public Person GetPersonWithID(int id)
        {
            lock (persons)
            {
                if (id < persons.Count) return (Person)persons[id].Clone();
                else return null;
            }
        }

        public bool AddNewPerson(Person person) {

            AddOrUpdatePhones(person.Phones);

            lock (persons)
            {
                int personId = persons.IndexOf(person);
                person.ID = personId;
            
                if (persons.Contains(person))
                {
                    return UpdatePersonWithID((int)person.ID, person);
                }
                        
                int id = persons.Count;
                person.ID = id;
                persons.Add((Person) person.Clone());
            }

            return true;
        }

        private void AddOrUpdatePhones(List<Phone> ph)
        {
            foreach (Phone p in ph)
            {
                lock (phones)
                {
                    int id = ph.IndexOf(p);
                    if (id == -1)
                    {
                        int pid = phones.Count;
                        p.ID = id;
                        phones.Add((Phone)p.Clone());
                    }
                    else
                    {
                        p.ID = id;
                    }
                }
            }
        }

        public bool UpdatePersonWithID(int id, Person person)
        {
            AddOrUpdatePhones(person.Phones);
            Person x;
            lock (persons)
            {
                x = persons[id];
                x.Name = person.Name;
                x.Organization = person.Organization;
                x.Phones = person.Phones;
            }
            return true;
        }

        public Person DeletePerson(int id)
        {
            Person x;
            lock (persons)
            {
                x = persons[id];
                persons.RemoveAt(id);
            }
            return x;
        }

    }
}