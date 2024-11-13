using VerifyPhoneNumber.API.DTO;
using VerifyPhoneNumber.API.Repository;
using VerifyPhoneNumber.API.Utils;

namespace VerifyPhoneNumber.API.VerifyPhoneNumber.Application
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public string ErrorMessage { get; private set; } = default!;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
       
        public async Task<ServiceResponse<CountryDTO>> GetCountryDetails(string phoneNumber)
        {
            var res = new ServiceResponse<CountryDTO>();

            if (!ValidateRequest(phoneNumber))
            {
                res.IsSuccessful = false;
                res.Error = ErrorMessage;
                return res;
            }
            var countryCode = phoneNumber.Substring(0, 3);
            var country = await _countryRepository.GetCountryByPhoneNumberAsync(countryCode);

            if (country == null)
            {
                res.IsSuccessful = false;
                res.Error = "Country not found";
                return res;
            }

            var result = new CountryDTO
            {
                PhoneNumber = phoneNumber,
                CountryCode = country.CountryCode,
                Name = country.Name,
                CountryIso = country.CountryIso,
                CountryId = country.CountryId,
                countryDetailsDTO = country.CountryDetails.Where(ci => ci.CountryId == country.CountryId)
                                                          .Select(cd => new CountryDetailsDTO
                                                            {
                                                                Operator = cd.Operator,
                                                                OperatorCode = cd.OperatorCode
                                                            })
                                                          .ToList(),
            };
            res.IsSuccessful = true;
            res.ResultData = result;
            return res;
        }

        private bool ValidateRequest(string request)
        {
            try
            {
                if (string.IsNullOrEmpty(request))
                {
                    ErrorMessage = "Phone number is empty or invalid";
                    return false;
                }
                var validNumber = ValHelper.IsValidNumber(request);
                if (!validNumber)
                {
                    ErrorMessage = "Please enter a valid number";
                    return false;
                }
                if(request.Length < 7 || request.Length > 15)
                {
                    ErrorMessage = "Phone number cannot be less than 7 or more than 15";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.GetBaseException().Message;
                return false;
            }
        }

        
    }
}
