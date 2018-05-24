using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestClient
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

        /*{
        "ID": 1,
        "Name": "sample string 2",
        "Organization": "sample string 3",
        "Phones": [
            {
                "ID": 1,
                "Number": "sample string 2"
            },
            {
                "ID": 1,
                "Number": "sample string 2"
            }
         ]
        }
        */
        internal string AsJSON()
        {
            string json = "{" + $" \"ID\":\"{this.ID}\"," +
                          $" \"Name\":\"{this.Name}\"," +
                          $" \"Organization\":\"{this.Organization}\"," +
                          $" \"Phones\": [";
            foreach (Phone phone in this.Phones)
            {
                json += "{" + $" \"ID\":\"{phone.ID}\", \"Number\":\"{phone.Number}\" " + "},";
            }
            
            json= json.Remove(json.Length - 1)+ "]}";

            return json;
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
 