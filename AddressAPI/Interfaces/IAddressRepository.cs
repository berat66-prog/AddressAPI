using AddressAPI.Controllers.DTO;
using AddressAPI.Model;

namespace AddressAPI.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddressedAsync();
        Task<Address> GetAddressByIdAsync(long id);
        Task<Address> addAddressAsync(AddressDTO addressDTO);
        Task<Address> updateAddressAsync(Address address);
        Task<Address> removeAddressAsync(long id);
        Task<List<Address>> GetAddressesWithSearching(AddressDTO addressDTP);
    }
}
