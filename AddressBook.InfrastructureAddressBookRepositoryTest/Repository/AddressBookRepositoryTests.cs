using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Domain.Entities;

namespace AddressBook.Infrastructure.Repository.Tests
{
    [TestClass()]
    public class AddressBookRepositoryTests
    {
        [TestMethod()]
        public void AddAddressTest()
        {
            var repository = new AddressBookRepository();
            var address = new Address(1, "ul. Królewska 1", "Warszawa", "00-001", "Jan Kowalski", "123-456-789", "jan.kowalski@example.com");


            repository.AddAddress(address);

            var result = repository.GetAllAddresses();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Jan Kowalski", result.First().Name);
        }

        [TestMethod()]
        public void RemoveAddressTest()
        {
            var repository = new AddressBookRepository();
            var address1 = new Address(1, "ul. Królewska 1", "Warszawa", "00-001", "Jan Kowalski", "123-456-789", "jan.kowalski@example.com");

            var address2 = new Address(2, "ul. Długa 15", "Kraków", "30-001", "Anna Nowak", "234-567-890", "anna.nowak@example.com");


            repository.AddAddress(address1);
            repository.AddAddress(address2);

            repository.RemoveAddress(1);

            var result = repository.GetAllAddresses();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Anna Nowak", result.First().Name);
        }
    }
}