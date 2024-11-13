using VerifyPhoneNumber.API.DTO;
using VerifyPhoneNumber.API.Entity;
using VerifyPhoneNumber.API.Utils;

namespace VerifyPhoneNumber.API.VerifyPhoneNumber.Application
{
    public interface ICountryService
    {
        Task<ServiceResponse<CountryDTO>> GetCountryDetails(string phoneNumber);
    }
}
