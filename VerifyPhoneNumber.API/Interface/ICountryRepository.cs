using VerifyPhoneNumber.API.Entity;

namespace VerifyPhoneNumber.API.Repository
{
    public interface ICountryRepository
    {
        Task<Country?> GetCountryByPhoneNumberAsync(string phoneNumber);
    }
}
