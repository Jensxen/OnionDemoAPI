using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application.Query;
using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressValidationController : ControllerBase
    {
        private readonly IAddressValidationQuery _addressValidationQuery;

        public AddressValidationController(IAddressValidationQuery addressValidationQuery)
        {
            _addressValidationQuery = addressValidationQuery;
        }

        [HttpGet("{street}/{city}/{postalCode}")]
        public IActionResult ValidateAddress(string street, string city, string postalCode)
        {
            var addressObj = new Address(street, city, postalCode);
            var isValid = _addressValidationQuery.ValidateAddress(addressObj);
            return Ok(isValid);
        }
    }
}