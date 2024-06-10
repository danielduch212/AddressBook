using Microsoft.AspNetCore.Mvc;
using AddressBook.Infrastructure.Repository;
using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Seeders;


namespace AddressBook.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly ILogger<AddressBookController> _logger;
        private IAddressBookRepository _repository;
        

        public AddressBookController(ILogger<AddressBookController> logger, IAddressBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [Route("addAddress")]
        public IActionResult AddAddress(AddressDTO address)
        {
            _logger.LogInformation($"Received POST request to add address: (address)");
            int id = _repository.ReturnId();
            Address newAddress = new Address(id,address.Street, address.City, address.PostalCode, address.Name, address.PhoneNumber, address.Email);
            bool checkIfDataValidate = _repository.CheckIfDataValidate(newAddress);
            if(!checkIfDataValidate)
            {
                return BadRequest("Nieprawidlowe dane");
            }
            if (!_repository.CheckIfExceptional(address.Email))
            {
                return BadRequest("Podany adres juz istnieje");
            }

            
            _repository.AddAddress(newAddress);
            return Ok("Dodano nowy adres");
        }

        [HttpGet]
        [Route("getAddress")]
        public Address GetAddress()
        {
            _logger.LogInformation($"Received GET request to get last address");

            return _repository.GetLastAddress();
        }

        [HttpGet]
        [Route("getAddress/{city}")]
        public IEnumerable<Address> GetAddressesByCity([FromRoute] string city)
        {
            _logger.LogInformation($"Received GET request to get address from given city name");

            return _repository.FindAllByCity(city);
            
        }

        [HttpGet]
        [Route("getAllAddress")]
        public IEnumerable<Address> GetAllAddresses()
        {
            _logger.LogInformation($"Received GET request to get all addresses");

            return _repository.GetAllAddresses();
        }

    }
}
