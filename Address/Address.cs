using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poo_ap1
{
    public class Address
    {
        public string Street { get; protected set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address(string street, int number, string city, string state)
        {
            this.Street = street;
            this.Number = number;
            this.City = city;
            this.State = state;
        }

        public string CompleteAddress()
        {
            string completeAddress = $"Rua: {this.Street}, N: {this.Number}, Cidade: {this.City}, Estado: {this.State}";
            return completeAddress;
        }
    }
}