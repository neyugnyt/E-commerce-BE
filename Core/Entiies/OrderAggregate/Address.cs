using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entiies.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string name, string street, string city, string state, string zipcode)
        {
            Name = name;
            Street = street;
            City = city;
            State = state;
            Zipcode = zipcode;
        }

        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
