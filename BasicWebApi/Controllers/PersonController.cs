using BasicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicWebApi.Controllers
{
    public class PersonController : ApiController
    {
        PhoneBook phoneBook = new PhoneBook();
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
