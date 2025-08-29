

using Application;
using Application.Commands;
using Application.DTOS;
using Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Merchant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly ILogger<MerchantController> _logger;
        public MerchantController(IDispatcher dispatcher, ILogger<MerchantController> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }
       
        [HttpGet()]
       // [Authorize]
        public  async Task<IActionResult> merchants()
        {
            _logger.LogInformation("Retrieving merchant data...");


        //   var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = "6377641f-33f7-4997-944c-997cc9d63d88"; // For testing purposes, replace with actual user ID retrieval logic
            _logger.LogWarning(">>> Usuério Logado ${userId}", userId);
            var result = await _dispatcher.Dispatch<GetMerchantsQuery, List<MerchantSummary>>(
                new GetMerchantsQuery{
                    UserId = userId
                });

        
            return Ok(result);
        }
        [HttpGet("{merchantId}")]
      //  [Authorize]
        public async Task<IActionResult> merchantDetails(string merchantId )
        {

            //merchantId:  b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d
            _logger.LogInformation("Retrieving merchant details for {MerchantId}...", merchantId);
         //   var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = "6377641f-33f7-4997-944c-997cc9d63d88"; // For testing purposes, replace with actual user ID retrieval logic

            _logger.LogWarning(">>> Usuério Logado ${userId}", userId);
            var result = await _dispatcher.Dispatch<GetMerchantDetailsQuery, MerchantDetailsDto>(
                new GetMerchantDetailsQuery
                {
                    MerchantId = merchantId,
                    UserId = userId
                });
            return Ok(result);
        }
        
        [HttpPatch("{merchantId}")]
        //[Authorize]
        public async Task<IActionResult> MerchantPatch(string merchantId,[FromBody] PatchMerchantDto patchMerchantDto)
        {
            _logger.LogInformation("Patching merchant with ID {MerchantId}...", merchantId);
            // var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = "6377641f-33f7-4997-944c-997cc9d63d88"; // For testing purposes, replace with actual user ID retrieval logic
            if (merchantId != patchMerchantDto.Id)
            {
                _logger.LogWarning("Merchant ID in the URL does not match the ID in the request body.");
                return BadRequest("Merchant ID mismatch.");
            }
            _logger.LogWarning(">>> Usuério Logado ${userId}", userId);
            var command = new UpdateMerchantsCommand
            {
                Id = merchantId,
                UsersId = userId,
                Name = patchMerchantDto.Name,
                Description = patchMerchantDto.Description,
                MainCuisine = patchMerchantDto.MainCuisine,
                DeliveryPhone = patchMerchantDto.DeliveryPhone
            };
            _logger.LogInformation("Processing update for merchant {MerchantId}...", merchantId);
            await _dispatcher.Dispatch<UpdateMerchantsCommand>(command);

            return Ok();
        }
    }
}
