using Microsoft.EntityFrameworkCore;
using VerifyPhoneNumber.API.DataStore.Context;
using VerifyPhoneNumber.API.Entity;
using VerifyPhoneNumber.API.Repository;

namespace VerifyPhoneNumber.API.DataStore.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;
        private readonly List<Country> _countries;

        public CountryRepository(AppDbContext context)
        {
            _countries = new List<Country>
            {
            new Country
            {
                CountryId = 1, CountryCode = "234", Name = "Nigeria", CountryIso = "NG",
                CountryDetails = new List<CountryDetail>
                {
                    new CountryDetail { CountryDetailId = 1, CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
                    new CountryDetail { CountryDetailId = 2, CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
                    new CountryDetail { CountryDetailId = 3, CountryId = 1, Operator = "9Mobile Nigeria", OperatorCode = "ETN" },
                    new CountryDetail { CountryDetailId = 4, CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" }
                }
            },
            new Country
            {
                CountryId = 2, CountryCode = "233", Name = "Ghana", CountryIso = "GH",
                CountryDetails = new List<CountryDetail>
                {
                    new CountryDetail { CountryDetailId = 5, CountryId = 2, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" },
                    new CountryDetail { CountryDetailId = 6, CountryId = 2, Operator = "MTN Ghana", OperatorCode = "MTN Ghana" },
                    new CountryDetail { CountryDetailId = 7, CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo Ghana" }
                }
            }
            };

            _context = context;
        }
        public async Task<Country?> GetCountryByPhoneNumberAsync(string countryCode)
        {
            return await Task.FromResult(_countries.FirstOrDefault(c => c.CountryCode == countryCode));
            //return await _context.Countries
            //    .Include(c => c.CountryDetails)
            //    .FirstOrDefaultAsync(c => c.CountryCode == countryCode);
        }
    }
}
