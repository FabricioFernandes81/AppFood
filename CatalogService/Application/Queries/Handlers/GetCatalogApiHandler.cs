
using Application.DTOS.catalog;
using Application.Exceptions;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Application.Queries.Handlers
{
    public class GetCatalogApiHandler : IQueryHandler<GetCatalogApiQuery, List<GetCatalogApiDto>>
    {
        private readonly ILogger<GetCatalogApiHandler> _logger;
        private readonly ICatalogRepository _catalogRepository;

        public GetCatalogApiHandler(ILogger<GetCatalogApiHandler> logger, ICatalogRepository catalogRepository)
        {
            _logger = logger;
            _catalogRepository = catalogRepository;
        }

        public async Task<List<GetCatalogApiDto>> Handle(GetCatalogApiQuery query)
        {
            if (Guid.TryParse(query.CatalogId, out Guid catalogId) && Guid.TryParse(query.MerchantId, out Guid merchantId))
            {
                var catalogs = await _catalogRepository.GetAll(merchantId, catalogId);
                
                List<GetCatalogApiDto> response = catalogs.Select(c=>new GetCatalogApiDto(c.CatalogoId.ToString(),c.Status.ToString(),c.Contexto
                    .Select(s=>s.ContextoType.ToString())
                    .ToList(),c.CatalogoGrupo.ToString()))
                   .ToList();
                

                return response;
            }
            else
            {
                _logger.LogError(">>> O IDs fornecidos são inválidos");
                throw new CustomValidationException(new[] { $"Produto com ID {query.MerchantId} não encontrado ou " });
                return null;

            }
            
        }
    }
}
