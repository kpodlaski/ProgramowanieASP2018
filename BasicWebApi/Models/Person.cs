using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class Person
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public String Organization { get; set; }
        public List<Phone> Phones { get; set; }

    }
}