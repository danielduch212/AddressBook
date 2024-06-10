using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Seeders
{
    internal class AddressBookSeeder : IAddressBookSeeder
    {
        private readonly IAddressBookRepository _repository;

        public AddressBookSeeder(IAddressBookRepository repository)
        {
            _repository = repository;
        }

        public void SeedData()
        {
            var addresses = new List<Address>
{
                new Address(1, "ul. Królewska 1", "Warszawa", "00-001", "Jan Kowalski", "123-456-789", "jan.kowalski@example.com"),
                new Address(2, "ul. Długa 15", "Kraków", "30-001", "Anna Nowak", "234-567-890", "anna.nowak@example.com"),
                new Address(3, "ul. Lipowa 20", "Gdańsk", "80-001", "Piotr Wiśniewski", "345-678-901", "piotr.wisniewski@example.com"),
                new Address(4, "ul. Północna 5", "Łódź", "90-001", "Katarzyna Wójcik", "456-789-012", "katarzyna.wojcik@example.com"),
                new Address(5, "ul. Wschodnia 7", "Wrocław", "50-001", "Andrzej Kamiński", "567-890-123", "andrzej.kaminski@example.com"),
                new Address(6, "ul. Zachodnia 9", "Poznań", "60-001", "Maria Lewandowska", "678-901-234", "maria.lewandowska@example.com"),
                new Address(7, "ul. Południowa 11", "Szczecin", "70-001", "Tomasz Zieliński", "789-012-345", "tomasz.zielinski@example.com"),
                new Address(8, "ul. Spacerowa 13", "Bydgoszcz", "85-001", "Agnieszka Szymańska", "890-123-456", "agnieszka.szymanska@example.com"),
                new Address(9, "ul. Kościuszki 17", "Lublin", "20-001", "Robert Kwiatkowski", "901-234-567", "robert.kwiatkowski@example.com"),
                new Address(10, "ul. Mickiewicza 19", "Katowice", "40-001", "Zofia Nowicka", "012-345-678", "zofia.nowicka@example.com")
            };

            foreach (var address in addresses)
            {
                _repository.AddAddress(address);
            }
        }
    }
}
