using AddressAPI.Model;
using GoogleMaps.LocationServices;

namespace Distances
{
    public class Distance
    {
        


        public Distance()
        {

        }

        public static void Main()
        {
            Console.WriteLine(calculateDistance());
        }

        public static double calculateDistance()
        {
            string addressPoint1 = "Trumanlaan 307";
            var gls = new GoogleLocationService("AIzaSyACdAYzS6dUff-JX3xFkAYQLi3oeiCXxrQ");
            var latlong = gls.GetLatLongFromAddress(addressPoint1);

            var latitude = latlong.Latitude;
            var longitude = latlong.Longitude;

            return latitude;

        }
    }
}
