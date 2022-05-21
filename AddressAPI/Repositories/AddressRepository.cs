using AddressAPI.Interfaces;
using AddressAPI.Model;
using AddressAPI.Controllers.DTO;
using AddressAPI.Exception;

namespace AddressAPI.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Address> addAddressAsync(AddressDTO addressDTO)
        {
            var address = new Address
            {
                Straat = addressDTO.Straat,
                Huisnummer = addressDTO.Huisnummer,
                Postcode = addressDTO.Postcode,
                Plaats = addressDTO.Plaats,
                Land = addressDTO.Land
            };
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;

        }

        public async Task<Address> GetAddressByIdAsync(long id)
        {
            var address = await _context.Addresses.FindAsync(id);
            
            if(address == null)
            {
                throw new RecordNotFoundException(id);
            }

            return address;
            
        }

        // Filtering and Sorting
        public async Task<List<Address>> GetAddressesWithSearching(AddressDTO addressdto)
        {
            var addresses = from a in _context.Addresses.Where(a => a.Straat == addressdto.Straat || a.Huisnummer == addressdto.Huisnummer || a.Postcode == addressdto.Postcode
                            || a.Plaats == addressdto.Plaats || a.Land == addressdto.Land)
                           select a;

           
            addresses = addresses.OrderBy(a => a.Straat).ThenByDescending(a => a.Huisnummer);
                

            return await addresses.ToListAsync();
        }

        public async Task<List<Address>> GetAllAddressedAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> removeAddressAsync(long id)
        {
            var addressdb = await _context.Addresses.FindAsync(id);

            if(addressdb == null) {
                throw new RecordNotFoundException(id);
            }

            _context.Addresses.Remove(addressdb);
            
            await _context.SaveChangesAsync();

            return addressdb;
        }

        public async Task<Address> updateAddressAsync(Address address)
        {
            var addressdb = await _context.Addresses.FindAsync(address.Id);

            if (addressdb == null)
            {
                throw new RecordNotFoundException(address.Id);
            }

            addressdb.Straat = address.Straat;
            addressdb.Huisnummer = address.Huisnummer;
            addressdb.Postcode = address.Postcode;
            addressdb.Plaats = address.Plaats;
            addressdb.Land = address.Land;
            
            await _context.SaveChangesAsync();

            return address;
        }
    }
}
