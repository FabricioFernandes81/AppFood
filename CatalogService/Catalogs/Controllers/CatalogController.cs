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
        [HttpGet("/merchants/{merchantId}/catalogs/{catalogId}", Name = "getCatalogApi", Order = 1)]
        public async Task<IActionResult> GetMenu(string merchantId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d", string catalogId = "50f8a1fc-1672-43e0-8746-aadcb005a3da")
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/catalog");

            var result = await _dispatcher.Dispatch<GetCatalogApiQuery, List<GetCatalogApiDto>>(new GetCatalogApiQuery(merchantId, catalogId));

            _logger.LogInformation("Requisição GET /api/catalog processada com sucesso");
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("/merchants/{merchantId}/catalogs", Name ="getCatalogApp", Order =2)]
        public async Task<IActionResult> Get(string merchantId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
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
