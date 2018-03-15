using System;
using System.Collections.Generic;

namespace BasicWebApi.Models
{
    public class Phone :ICloneable
    {
        public long ID { get; set; }
        public string Number { get; set; }


        public override bool Equals(object obj)
        {
            var phone = obj as Phone;
            return phone != null &&
                   Number == phone.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + EqualityComparer<string>.Default.GetHashCode(Number);
        }


        public object Clone()
        {
            return new Phone() { ID = ID, Number = (String) Number.Clone() };
        }
    }


}