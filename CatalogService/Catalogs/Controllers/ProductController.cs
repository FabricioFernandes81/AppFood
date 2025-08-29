using Application;
using Application.DTOS.product;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IDispatcher _dispatcher;
        public ProductController(ILogger<ProductController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(
            [FromQuery]int page = 1, 
            [FromQuery]int pageSize = 10, 
            [FromQuery]string ownerId = null){
            _logger.LogInformation("Iniciando processamento da requisição GET /api/products");
            
            var result = await _dispatcher.Dispatch<GetPageProductQuery, GetProductResponseDto>(new GetPageProductQuery(page, pageSize, ownerId));
            _logger.LogInformation("Requisição GET /api/products processada com sucesso");
            return Ok(result);
        }
    }
}
