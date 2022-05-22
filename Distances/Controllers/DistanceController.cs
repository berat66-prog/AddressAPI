using AddressAPI.Exception;
using AddressAPI.Model;
using Distances.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Distances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceRepository _distanceRepository;

        public DistanceController(IDistanceRepository distanceRepository)
        {
            _distanceRepository = distanceRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Calculate distance", Description = "Calculates the distance between two address points based on address ID in the database. Fill in the id's of the addresses that exists in the database")]
        [SwaggerResponse(StatusCodes.Status200OK, "Request Successful")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Address with given ID not found in the database")]
        public async Task<ActionResult<string>> calculateDistanceBetweenTwoPoints([FromQuery] long point1Id,  long point2Id)
        {
            try
            {
                return Ok(await _distanceRepository.calculateDistanceBetweenTwoPoints(point1Id, point2Id));
            }
            catch (RecordNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
