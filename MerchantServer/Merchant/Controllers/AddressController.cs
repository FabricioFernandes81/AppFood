using Application;
using Application.Commands;
using Application.DTOS;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IDispatcher _dispatcher;

        public AddressController(IDispatcher dispatcher, ILogger<AddressController> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }
        [HttpGet("{merchantId}/address")]
        // [Authorize]
        public async Task<IActionResult> merchantAddress(string merchantId)
        {
            _logger.LogInformation("Retrieving merchant address for {MerchantId}...", merchantId);
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = "6377641f-33f7-4997-944c-997cc9d63d88"; // For testing purposes, replace with actual user ID retrieval logic
            _logger.LogWarning(">>> Usuério Logado ${userId}", userId);
            var result = await _dispatcher.Dispatch<GetMerchantAddressQuery, AddressDto>(
                new GetMerchantAddressQuery
                (merchantId, userId
                ));
            return Ok(result);
        }

        [HttpPatch("{merchantId}/address")]
        // [Authorize]
        public async Task<IActionResult> updateAddress(string merchantId, [FromBody] PatchAddressDto address)
        {
            _logger.LogInformation("Updating address for merchant {MerchantId}...", merchantId);
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = "6377641f-33f7-4997-944c-997cc9d63d88"; // For testing purposes, replace with actual user ID retrieval logic
            _logger.LogWarning(">>> Usuério Logado ${userId}", userId);

            await _dispatcher.Dispatch<UpdateMerchantAddressCommand>(new UpdateMerchantAddressCommand(
                merchantId, userId,address.address, address.streetNumber, address.Complement, address.District, address.City, address.State, address.Country,
                address.ZipCode, address.Latitude, address.Longitude

                ));
            return Ok();

        }

    }
}
