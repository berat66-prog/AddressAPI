using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressAPI.Model;
using AddressAPI.Interfaces;
using AddressAPI.Controllers.DTO;
using AddressAPI.Exception;
using Swashbuckle.AspNetCore.Annotations;

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


        [HttpGet(Name = "GetAllAddresses")]
        [SwaggerOperation(Summary = "Gets all addresses", Description = "Gets all the addresses data from the database")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        public async Task<ActionResult<List<Address>>> Get()
        {
            return Ok(await _addressRepository.GetAllAddressedAsync());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get address by ID", Description = "Gets a unique address by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Address with given ID not found in the database")]

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
        [SwaggerOperation(Summary = "Filters and sorts", Description = "Filters and sorts the addresses based on given query params")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        public async Task<ActionResult<List<Address>>> GetAddressBySearching([FromQuery] AddressDTO addressDTO)
        {
            return Ok(await _addressRepository.GetAddressesWithSearching(addressDTO));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Saves Address", Description = "Saves an address to the database")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        public async Task<ActionResult<Address>> AddAddress(AddressDTO addressDTO)
        {
             return Ok(await _addressRepository.addAddressAsync(addressDTO));
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Modify address", Description = "Makes changes to the address and saves it")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Address with given ID not found in the database")]
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
        [SwaggerOperation(Summary = "Delete Address", Description = "Deletes an address from the database")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Address with given ID not found in the database")]
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
