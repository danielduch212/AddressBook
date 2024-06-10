using AddressBook.Domain.Entities;
using AddressBook.Infrastructure.Seeders;

namespace AddressBook.Infrastructure.Repository
{
    public interface IAddressBookRepository
    {
        void AddAddress(Address address);
        Address GetAddress(int id);
        List<Address> GetAllAddresses();
        void RemoveAddress(int id);
        int ReturnId();
        bool CheckIfDataValidate(Address address);
        bool CheckIfExceptional(string email);
        Address GetLastAddress();
        IEnumerable<Address> FindAllByCity(string city);

    }
}