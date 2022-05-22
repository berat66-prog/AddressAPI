using Swashbuckle.AspNetCore.Annotations;

namespace AddressAPI.Model
{
    public class Address
    {
        [SwaggerSchema(Description = "Id for Address")]
        public long Id { get; set; }
        
        [SwaggerSchema(Description = "Street name of the address")]
        public string Straat { get; set; } = string.Empty;

        [SwaggerSchema(Description = "House number of the address")]
        public int Huisnummer { get; set; }

        [SwaggerSchema(Description = "Zip code of the address")]
        public string Postcode { get; set; } = string.Empty;
        
        [SwaggerSchema(Description = "City name of the address")]
        public string Plaats { get; set; } = string.Empty;

        [SwaggerSchema(Description = "Country name of the address")]
        public string Land { get; set; } = string.Empty;

        public Address()
        {

        }

        public Address(long Id, string Straat, int Huisnummer, string Postcode,
                        string Plaats, string Land)
        {
            this.Id = Id;
            this.Straat = Straat;
            this.Huisnummer = Huisnummer;
            this.Postcode = Postcode;
            this.Plaats = Plaats;
            this.Land = Land;
        }


        public string GetFullAddressAsString()
        {
            return String.Format("{0} {1}, {2}, {3}, {4}",Straat,Huisnummer, Postcode, Plaats,Land);
        }

    }
}
