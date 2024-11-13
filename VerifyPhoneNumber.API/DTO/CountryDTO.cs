using VerifyPhoneNumber.API.Utils;

namespace VerifyPhoneNumber.API.DTO
{
    public class CountryDTO : IServiceResponse
    {
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string CountryCode { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CountryIso { get; set; } = default!;
        public List<CountryDetailsDTO> countryDetailsDTO { get; set; } = default!;
    }
}
