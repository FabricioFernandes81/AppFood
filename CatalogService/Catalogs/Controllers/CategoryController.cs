using Application;
using Application.Commands;
using Application.DTOS.categories;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IDispatcher _dispatcher;

        public CategoryController(ILogger<CategoryController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        [HttpGet("/merchants/{merchantId}/categories")]
        public async Task<IActionResult> Get(string merchantId)
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/categories");
            var query = new GetCategoryQuery(
                merchantId: merchantId
            );
            var result = await _dispatcher.Dispatch<GetCategoryQuery, List<GetCategoryDto>>(query);
            _logger.LogInformation("Requisição GET /api/categories processada com sucesso");
                
            return Ok(result);



        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategory(string categoryId, [FromQuery] string merchantId )
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/categories/{categoryId}");
       
             var query = new GetCategoryByIdQuery(categoryId,merchantId);
             var result = await _dispatcher.Dispatch<GetCategoryByIdQuery, GetCategoryDto>(query);
            
            _logger.LogInformation("Requisição GET /api/categories/{categoryId} processada com sucesso");
            return Ok(result); 
        }

        ///merchants/{merchantId}/catalogs/{catalogId}/categories
        [HttpPost("/merchants/{merchantId}/categories")]
        public async Task<IActionResult> Post(string merchantId,[FromBody] PostCategoryDto postCategoryDto)
        {
            _logger.LogInformation("Iniciando processamento da requisição POST /api/categories");
            
            var command = new CreateCategoryCommand(merchantId, postCategoryDto);
             await _dispatcher.Dispatch<CreateCategoryCommand>(command);
            
            _logger.LogInformation("Requisição POST /api/categories processada com sucesso");
            return CreatedAtAction(nameof(Get), new { merchantId = merchantId }, null);
        }

    }
}
