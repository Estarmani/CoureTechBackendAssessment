namespace VerifyPhoneNumber.API.Entity
{
    public class CountryDetail
    {
        public int CountryDetailId { get; set; }
        public int CountryId { get; set; }
        public string Operator { get; set; } = default!;
        public string OperatorCode { get; set; } = default!;
        public Country Country { get; set; } = default!;
    }
}
