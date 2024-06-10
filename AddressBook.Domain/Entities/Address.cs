using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email {  get; set; }


        public Address(int id, string street, string city, string postalCode, string name, string phoneNumber, string email)
        {
            Id = id;
            Street = street;
            City = city;
            PostalCode = postalCode;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
