using Application.DTOS.catalog;
using Application.Exceptions;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetCatalogHandler : IQueryHandler<GetCatalogQuery, List<GetCatalogDto>>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly ILogger<GetCatalogHandler> _logger;

        public GetCatalogHandler(ICatalogRepository catalogRepository, ILogger<GetCatalogHandler> logger)
        {
            _catalogRepository = catalogRepository;
            _logger = logger;
        }

        public async Task<List<GetCatalogDto>> Handle(GetCatalogQuery query)
        {
            _logger.LogInformation(">>> Consultando Catálogos disponíveis para o comerciante com ID: {MerchantId}", query.MerchantId);

            if (Guid.TryParse(query.MerchantId, out Guid merchantGuid))
            {
                var entityCatalogo = await _catalogRepository.GetCatalogsByMerchantIdAsync(merchantGuid);
                if (entityCatalogo == null || !entityCatalogo.Any())
                {
                    _logger.LogWarning(">>> Nenhum catalogo encontrado para o comerciante com ID: {MerchantId}", query.MerchantId);
                    return new List<GetCatalogDto>();
                }

                List<GetCatalogDto> result = entityCatalogo.Select(cat=>new GetCatalogDto
                {
                    CatalogId = cat.CatalogoId.ToString(),
                    OwnerId = cat.ComercioId.ToString(),
                    CatalogName = cat.Nome,
                    CatalogDescription = cat.Descricao,
                    Status = cat.Status.ToString(),
                    CatalogGroup = cat.CatalogoGrupo.ToString(),
                    CatalogType = cat.Tipo.ToString(),
                    Available = cat.Disponivel,

                }).ToList();

              


                return result;
            }
            else {        
                _logger.LogError(">>> Falha ao converter o ID do comerciante: {MerchantId} para GUID", query.MerchantId);
                throw new CustomValidationException(new[] { "MerchantId inválido. Certifique-se de que é um GUID válido." });
            }
           
        }
    }
}
