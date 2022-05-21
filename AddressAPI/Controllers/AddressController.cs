using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressAPI.Model;
using AddressAPI.Interfaces;
using AddressAPI.Controllers.DTO;
using AddressAPI.Exception;

namespace AddressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            return Ok(await _addressRepository.GetAllAddressedAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetById(long id)
        {
            try
            {
                var address = await _addressRepository.GetAddressByIdAsync(id);
                return Ok(address);
            }
            catch(RecordNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        // Filtering and Sorting

        [HttpGet("/search")]
        public async Task<ActionResult<List<Address>>> GetAddressBySearching([FromQuery] AddressDTO addressDTO)
        {
            return Ok(await _addressRepository.GetAddressesWithSearching(addressDTO));
        }

        [HttpPost]
        public async Task<ActionResult<Address>> AddAddress(AddressDTO addressDTO)
        {
             return Ok(await _addressRepository.addAddressAsync(addressDTO));
        }

        [HttpPut]
        public async Task<ActionResult<Address>> UpdateAddress(Address address)
        {
            try
            {
                return Ok(await _addressRepository.updateAddressAsync(address));

            }catch(RecordNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Address>>> DeleteAddress(long id)
        {
            try
            {
                return Ok(await _addressRepository.removeAddressAsync(id));
            }catch (RecordNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        
            
        }
    }   

}
