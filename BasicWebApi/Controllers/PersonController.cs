using BasicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicWebApi.Controllers
{
    public class PersonController : ApiController
    {
        static PhoneBook phoneBook = new PhoneBook();
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return phoneBook.persons;

        }

        // GET: api/Person/5
        public Person Get(int id)
        {
            return phoneBook.persons[id];
        }

        // POST: api/Person
        public Person Post([FromBody]Person person)
        {
            Debug.WriteLine("Zapytanie Post");
            Debug.WriteLine(person.Name);
            //Należało by sprawdzić czy osoba istnieje w phonebook
            lock (phoneBook) {
                int id = phoneBook.persons.Count;
                person.ID = id;
                phoneBook.persons.Add(person);
            }
            return person;
        }

        // PUT: api/Person/5
        public Person Put(int id, [FromBody]Person person)
        {
            Person x;
            lock (phoneBook) { 
                x = phoneBook.persons[id];
                x.Name = person.Name;
                x.Organization = person.Organization;
                x.Phones = person.Phones;
            }
            return x;
        }

        // DELETE: api/Person/5
        public Person Delete(int id)
        {
            Person x;
            lock (phoneBook)
            {
                x = phoneBook.persons[id];
            }
            return x;
        }
    }
}
