using Application;
using Application.Commands;
using Application.DTOS.items;
using Application.DTOS.items.postStatus;
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
        public async Task<IActionResult> Item(string categoryId = "c1a5f8e2-3b6d-4f8e-9c7e-0d8f9a1b2c3d", string ownerId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d")
        {
            _logger.LogInformation("Iniciando processamento da requisição GET /category/{categoryId}/items");
            var result = await _dispatcher.Dispatch<GetItemsByCategoryQuery, ItemDto>(
                new GetItemsByCategoryQuery(categoryId, ownerId)
            );
            _logger.LogInformation("Requisição GET /category/{categoryId}/items processada com sucesso");
            return Ok(result);
        }


        [HttpPatch("/status")]
        public async Task<IActionResult> Status([FromQuery]string merchantId = "b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d", [FromBody] PUTItemsStatusDto statusput = null)
        {
            _logger.LogInformation("Iniciando processamento da requisição PUT /items/status");

            return null;
            /*
             {
                  "options": [
                    {
                      "optionId": "0d58a046-1871-433d-bd8d-2b33abfbfa70",
                      "parentOptionId": "945ef3bc-7741-4bec-a0ce-4660c09a564f",
                      "status": "UNAVAILABLE",
                      "statusByCatalog": [
                        {
                          "status": "UNAVAILABLE",
                          "catalogId": "50f8a1fc-1672-43e0-8746-aadcb005a3da",
                          "catalogType": "DEFAULT",
                          "available": true
                        }
                      ]
                    }
                  ]
                }
             */

           /* if (statusput.Options != null)
            {
                foreach (var option in statusput.Options)
                {
                    PutOptionStatusCommand editOption = new PutOptionStatusCommand
                    {
                        MerchantId = mercnhaId,
                        Id = option.OptionId,
                        ParentOptionId = option.parentOptionId,
                        Status = option.Status,
                        StatusByCatlogs = option.StatusByCatalog
                    };
                    await _dispatcher.Dispatch<PutOptionStatusCommand>(editOption);
                }
            }
            else
            {
                PutItemStatusCommand edit = new PutItemStatusCommand
                {
                    MerchantId = mercnhaId,
                    Id = statusput.CatalogItemId,
                    Status = statusput.Status,
                    StatusByCatlogs = statusput.statusByCatalog

                };
                await _dispatcher.Dispatch<PutItemStatusCommand>(edit);
            }
               


            return NoContent();*/

        }
    }
}
