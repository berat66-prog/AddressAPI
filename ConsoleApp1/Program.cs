// See https://aka.ms/new-console-template for more information
using GoogleMaps.LocationServices;
using GeoCoordinatePortable;
using AddressAPI.Model;


Address point1 = new Address { Straat = "Trumanlaan", Huisnummer = 307, Postcode = "3527 BJ", Plaats = "Utrecht", Land = "Nederland" };
Address point2 = new Address { Straat = "Blokstraat", Huisnummer = 2, Postcode = "3513 VL", Plaats = "Utrecht", Land = "Nederland" };

Console.WriteLine(calculateDistance(point1,point2));

 static double calculateDistance(Address point1, Address point2)
{
   /* string addressPoint1 = "Trumanlaan 307";
    string addressPoint2 = "Blokstraat 2, Utrecht";*/
    var gls = new GoogleLocationService("AIzaSyACdAYzS6dUff-JX3xFkAYQLi3oeiCXxrQ");
    var latlong = gls.GetLatLongFromAddress(point1.GetFullAddressAsString());
    var latlong2 = gls.GetLatLongFromAddress(point2.GetFullAddressAsString());
    
    var latitude = latlong.Latitude;
    var longitude = latlong.Longitude;

    var pointA = new GeoCoordinate(latitude, longitude);
    var pointB = new GeoCoordinate(latlong2.Latitude, latlong2.Longitude);

    var distanceInKM = pointA.GetDistanceTo(pointB) / 1000;

    

    return distanceInKM;

}


//Deze stuk code verplaatsen naar endpoint in addressController
    
//Weatherforecast code verwijderen
