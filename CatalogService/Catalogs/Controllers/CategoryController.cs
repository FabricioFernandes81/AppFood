using Application;
using Application.Commands;
using Application.DTOS.categories;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        ///merchants/{merchantId}/catalogs/{catalogId}/categories   ---------Menu Aplicativo
        [HttpGet("/merchants/{merchantId}/catalogs/{catalogId}/categories")]
        public async Task<IActionResult> GetApp(string merchantId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d", string catalogId = "50f8a1fc-1672-43e0-8746-aadcb005a3da",
            [FromQuery]bool includeItems = false)
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/categories");
            var query = new GetCategoryAppQuery
            {
                MerchantId = merchantId,
                CatalogId = catalogId,
                IncludeItems = includeItems
            };

            var result = await _dispatcher.Dispatch<GetCategoryAppQuery, List<GetCategoryAppDto>>(query);
            
            _logger.LogInformation("Requisição GET /api/categories processada com sucesso");
              

          
            return result.Any() ? Ok(result) : NotFound();



        }
        // "/merchants/{merchantId}/categories"
        [HttpGet("/merchants/{merchantId}/categories")]
        public async Task<IActionResult> Get(string merchantId)
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /api/categoriesApp");
            var query = new GetCategoryQuery 
            {
                MerchantId = merchantId
            };

            var result = await _dispatcher.Dispatch<GetCategoryQuery, List<GetCategoryDto>>(query);
          _logger.LogInformation("Requisição GET /api/categories processada com sucesso");
            
          
           
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPatch("/merchants/{merchantId}/status")]
        public async Task<IActionResult> Status([FromQuery]string status = "enable", string merchantId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d", string categoryId = "d2b6f9e3-4c7e-5f9f-0d8f-1a2b3c4d5e6f")
        {
            _logger.LogInformation("Iniciando processamento de requisição PATCH status ");

            var query = new StatusCategoryCommand
            {
                MerchantId = merchantId,
                CatagoryId = categoryId,
                Status = status
                
            };
             await _dispatcher.Dispatch<StatusCategoryCommand>(query);

            return NoContent();
        }


        /*  [HttpGet("{categoryId}")]
          public async Task<IActionResult> GetCategory(string categoryId, [FromQuery] string merchantId )
          {
              _logger.LogInformation("Iniciando processamento da requisição GET /api/categories/{categoryId}");

               var query = new GetCategoryByIdQuery(categoryId,merchantId);
               var result = await _dispatcher.Dispatch<GetCategoryByIdQuery, GetCategoryDto>(query);

              Requisição GET /api/categories/{categoryId} processada com sucesso");
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
          }*/

    }
}
