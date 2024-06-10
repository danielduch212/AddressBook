using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Seeders;

namespace AddressBook.Infrastructure.Repository
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private List<Address> addresses = new List<Address>();
        
        
        public void AddAddress(Address address)
        {
            addresses.Add(address);
        }
        public void RemoveAddress(int id)
        {
            var address = addresses.FirstOrDefault(x => x.Id == id);
            if (address != null)
                addresses.Remove(address);
        }
        public List<Address> GetAllAddresses() { return addresses; }
        public Address GetAddress(int id)
        {
            var address = addresses.FirstOrDefault(x => x.Id == id);
            return address;
        }

        public Address GetLastAddress()
        {
            if (addresses.Count == 0)
            {
                return null;
            }
            return addresses[addresses.Count - 1];
        }

        public int ReturnId()
        {
            return addresses.Count() + 1;
        }


        public IEnumerable<Address> FindAllByCity(string city)
        {
            return addresses.FindAll(x=>x.City == city);
        }


        public bool CheckIfDataValidate(Address address)
        {
            return new[] { address.Street, address.City, address.PostalCode, address.Name, address.PhoneNumber }.All(field => !string.IsNullOrWhiteSpace(field)) && IsValidEmail(address.Email);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        public bool CheckIfExceptional(string email)
        {
            var address = addresses.FirstOrDefault(x => x.Email == email);
            if (address != null)
            {
                return false;
            }
            else
            {
                return true;
            }
                
        }

        
    }
}
