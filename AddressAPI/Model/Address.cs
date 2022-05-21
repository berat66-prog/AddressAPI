namespace AddressAPI.Model
{
    public class Address
    {
        public long Id { get; set; }
        public string Straat { get; set; } = string.Empty;
        public int Huisnummer { get; set; }
        public string Postcode { get; set; } = string.Empty;
        public string Plaats { get; set; } = string.Empty;
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

    }
}
