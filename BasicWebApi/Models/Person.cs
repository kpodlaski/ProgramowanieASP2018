using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class Person : ICloneable
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public String Organization { get; set; }
        public List<Phone> Phones { get; set; }


        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Name == person.Name &&
                   Organization == person.Organization;
        }

        public override int GetHashCode()
        {
            var hashCode = 965954816;
            hashCode = hashCode * -1521134295 + 
                EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + 
                EqualityComparer<string>.Default.GetHashCode(Organization);
            return hashCode;
        }


        public object Clone()
        {
            List<Phone> phones = Phones.Select(phone => (Phone) phone.Clone()).ToList();
            return new Person() {
                ID = this.ID,
                Name = (String) this.Name.Clone(),
                Organization = (String) this.Organization.Clone(),
                Phones = phones
            };
        }
    }
}