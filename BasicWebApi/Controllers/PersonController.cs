using BasicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BasicWebApi.Controllers
{
    public class PersonController : ApiController
    {
        static PhoneBook phoneBook = new PhoneBook();
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            return phoneBook.GetPersons();

        }

        /// <summary>
        /// Looks up persons from phonebook by ID.
        /// </summary>
        /// <param name="id">The ID of the person to be retrived.</param>
        // GET: api/Person/5
        public Person Get(int id)
        {
            Person p = phoneBook.GetPersonWithID(id);
            if (p == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Unable to find any results")
                };
                throw new HttpResponseException(response);
            }
            return p;
        }

        // POST: api/Person
        public Person Post([FromBody]Person person)
        {
            Debug.WriteLine("Zapytanie Post");
            Debug.WriteLine(person.Name);
            if (!phoneBook.AddNewPerson(person))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Unable to find any results")
                };
                throw new HttpResponseException(response);
            }
            return person;
            
        }

        // PUT: api/Person/5
        public Person Put(int id, [FromBody]Person person)
        {
            if (!phoneBook.UpdatePersonWithID(id, person))
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Unable to find any results")
                };
                throw new HttpResponseException(response);
            }
            return person;
        }

        // DELETE: api/Person/5
        public Person Delete(int id)
        {
            
            return phoneBook.DeletePerson(id);
        }
    }
}
