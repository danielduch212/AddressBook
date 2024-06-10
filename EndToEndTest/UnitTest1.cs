using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using AddressBook.API;
using AddressBook.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

namespace EndToEndTest
{
    public class TestE2E : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AddressBookApiTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddAddress_ShouldReturnOk()
        {
            // Arrange
            var address = new AddressDTO
            {
                Street = "ul. Królewska 1",
                City = "Warszawa",
                PostalCode = "00-001",
                Name = "Jan Kowalski",
                PhoneNumber = "123-456-789",
                Email = "jan.kowalski@example.com"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/AddressBook/addAddress", address);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("Dodano nowy adres");
        }

        [Fact]
        public async Task GetLastAddress_ShouldReturnLastAddedAddress()
        {
            // Act
            var response = await _client.GetAsync("/AddressBook/getAddress");
            response.EnsureSuccessStatusCode();

            var address = await response.Content.ReadFromJsonAsync<Address>();

            // Assert
            address.Should().NotBeNull();
            address.City.Should().Be("Warszawa");
        }

        [Fact]
        public async Task GetAddressesByCity_ShouldReturnAddresses()
        {
            // Act
            var response = await _client.GetAsync("/AddressBook/getAddress/Warszawa");
            response.EnsureSuccessStatusCode();

            var addresses = await response.Content.ReadFromJsonAsync<IEnumerable<Address>>();

            // Assert
            addresses.Should().NotBeEmpty();
            addresses.Should().Contain(a => a.City == "Warszawa");
        }
    }

}
