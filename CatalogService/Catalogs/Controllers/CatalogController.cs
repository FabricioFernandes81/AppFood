using Application;
using Application.DTOS.catalog;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly IDispatcher _dispatcher;

        public CatalogController(ILogger<CatalogController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        [HttpGet("/merchants/{merchantId}/catalogs")]

        
        public async Task<IActionResult> Get(string merchantId)
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/catalog");
            var query = new GetCatalogQuery
            {
                MerchantId = merchantId,
            };
            var result = await _dispatcher.Dispatch<GetCatalogQuery, List<GetCatalogDto>>(query);
            _logger.LogInformation("Requisição GET /api/catalog processada com sucesso");
            return Ok(result);
        }
    }
}
