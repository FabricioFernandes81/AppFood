using Application;
using Application.DTOS;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merchant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly ILogger<CuisinesController> _logger;
        private readonly IDispatcher _dispatcher;

        public CuisinesController(IDispatcher dispatcher, ILogger<CuisinesController> logger)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher), "Dispatcher cannot be null");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null");
        }

        [HttpGet(Name ="types")]
        
        public async Task<IActionResult> GetTypes()
        {
            _logger.LogInformation("Retrieving cuisine types...");
            var result = await _dispatcher.Dispatch<GetCuisinesQuery, List<CuisinesDto>>(
                new GetCuisinesQuery());

            return Ok(result);
        
        }
    }
}
