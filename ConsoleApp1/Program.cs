// See https://aka.ms/new-console-template for more information
using GoogleMaps.LocationServices;

Console.WriteLine(calculateDistance());

 static double calculateDistance()
{
    string addressPoint1 = "Trumanlaan 307";
    var gls = new GoogleLocationService("AIzaSyACdAYzS6dUff-JX3xFkAYQLi3oeiCXxrQ");
    var latlong = gls.GetLatLongFromAddress(addressPoint1);

    var latitude = latlong.Latitude;
    var longitude = latlong.Longitude;

    return latitude;

}
