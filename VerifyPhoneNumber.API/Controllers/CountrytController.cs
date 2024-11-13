using Microsoft.AspNetCore.Mvc;
using VerifyPhoneNumber.API.Repository;
using VerifyPhoneNumber.API.VerifyPhoneNumber.Application;

namespace VerifyPhoneNumber.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountrytController : ControllerBase
    {

        private readonly ILogger<CountrytController> _logger;
        private readonly ICountryService _countryService;


        public CountrytController(ILogger<CountrytController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCountryDetails(string phoneNumber)
        {
            var result = await _countryService.GetCountryDetails(phoneNumber);

            if (result.IsSuccessful == false)
            {
                return BadRequest(result.Error);
            }
            if (result == null)
            {
                return NotFound("Country not found");
            }

            return Ok(result);
        }
    }
}
