using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class PhoneBook
    {
        public List<Person> persons; 

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
    }
}