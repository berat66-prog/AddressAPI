using AddressAPI.Model;

namespace AddressAPI.Controllers.DTO
{
    public class AddressDTO
    {

        public string Straat { get; set; } = string.Empty;
        public int Huisnummer { get; set; }
        public string Postcode { get; set; } = string.Empty;
        public string Plaats { get; set; } = string.Empty;
        public string Land { get; set; } = string.Empty;

        public AddressDTO()
        {

        }

        public AddressDTO(Address address)
        {
            
            this.Straat = address.Straat;
            this.Huisnummer = address.Huisnummer;
            this.Postcode = address.Postcode;
            this.Plaats = address.Plaats;
            this.Land = address.Land;
        }

    }
}
