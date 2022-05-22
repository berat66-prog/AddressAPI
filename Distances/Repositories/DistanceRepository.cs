using AddressAPI.Controllers.DTO;
using AddressAPI.Data;
using AddressAPI.Interfaces;
using AddressAPI.Model;
using Distances.Interfaces;
using Distances.Model;

namespace Distances.Repositories
{
    public class DistanceRepository : IDistanceRepository
    {
        private readonly IAddressRepository _addressRepository;

        public DistanceRepository(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            
        }
        public async Task<string> calculateDistanceBetweenTwoPoints(long point1Id, long poin2Id)
        {
            Address point1db = await _addressRepository.GetAddressByIdAsync(point1Id);
            Address point2db = await _addressRepository.GetAddressByIdAsync(poin2Id);

            DistanceCalculator calculator = new DistanceCalculator("AIzaSyACdAYzS6dUff-JX3xFkAYQLi3oeiCXxrQ");

            return calculator.CalculateDistance(point1db, point2db);
        }
    }
}
