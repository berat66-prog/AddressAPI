using AddressAPI.Model;
using GoogleMaps.LocationServices;
using GeoCoordinatePortable;

namespace Distances.Model
{
    public class DistanceCalculator
    {
        private string GOOGLE_MAPS_API_KEY;
        


        public DistanceCalculator(string ApiKey)
        {
            this.GOOGLE_MAPS_API_KEY = ApiKey;
        }

        public string CalculateDistance(Address point1, Address point2)
        {

            var gls = new GoogleLocationService(GOOGLE_MAPS_API_KEY);
            var latlong = gls.GetLatLongFromAddress(point1.GetFullAddressAsString());
            var latlong2 = gls.GetLatLongFromAddress(point2.GetFullAddressAsString());

            var latitude = latlong.Latitude;
            var longitude = latlong.Longitude;

            var pointA = new GeoCoordinate(latitude, longitude);
            var pointB = new GeoCoordinate(latlong2.Latitude, latlong2.Longitude);

            var distanceInKM = pointA.GetDistanceTo(pointB) / 1000;



            return String.Format("Distance between {0} AND {1} is {2} km", point1.GetFullAddressAsString(), point2.GetFullAddressAsString(), Math.Round(distanceInKM,2));

        }
    }
}
