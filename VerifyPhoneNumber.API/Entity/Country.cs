namespace VerifyPhoneNumber.API.Entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CountryIso { get; set; } = default!;
        public List<CountryDetail> CountryDetails { get; set; } = default!;
    }
}
