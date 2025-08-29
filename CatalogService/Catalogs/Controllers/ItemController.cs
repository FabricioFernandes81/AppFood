using Application;
using Application.DTOS.items;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly ILogger<ItemController> _logger;
        private readonly IDispatcher _dispatcher;

        public ItemController(ILogger<ItemController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }


        [HttpGet("/category/{categoryId}/items")]
        public async Task<IActionResult> Item(string categoryId, string ownerId)
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /category/{categoryId}/items");
            var result = await _dispatcher.Dispatch<GetItemsByCategoryQuery, ItemDto>(
                new GetItemsByCategoryQuery(categoryId, ownerId)
            );
              _logger.LogInformation("Requisição GET /category/{categoryId}/items processada com sucesso");
            return Ok(result);
        }
    }
}
