using Application.DTOS.categories;
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
    public class GetCategoryHandler : IQueryHandler<GetCategoryQuery, List<GetCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<GetCategoryHandler> _logger;

        public GetCategoryHandler(ICategoryRepository categoryRepository, ILogger<GetCategoryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<List<GetCategoryDto>> Handle(GetCategoryQuery query)
        {
           _logger.LogInformation(">>> Consultando categorias disponíveis para o comerciante com ID: {MerchantId}", query.MerchantId);
            string id = query.MerchantId?.Trim();
            if (Guid.TryParse(id, out Guid merchantGuid))
            {
                var categories = await _categoryRepository.GetCategoriesAsync(merchantGuid);

                if (categories == null || !categories.Any())
                {
                    _logger.LogWarning(">>> Nenhuma categoria encontrada para o comerciante com ID: {MerchantId}", query.MerchantId);
                    return new List<GetCategoryDto>();
                }
                 List<GetCategoryDto> categoryDtos = categories.Select(c => new GetCategoryDto 
                 {
                  CategoryId = c.CategoriaId.ToString(),
                  Name = c.Nome,
                  Description = c.Descricao,
                  Status = c.Status.ToString(),
                  Type = c.Tipo.ToString(),
                  CanEdit = true,
                  HasViolations = false,
                  Available = true,
                  ItemCount = c.Items?.Count ?? 0,
                  Items = null // Ou mapear os itens conforme necessário


                 }).ToList();
                return categoryDtos;
            }
            else
            {
                _logger.LogError(">>> Falha ao converter o ID do comerciante: {MerchantId} para GUID", query.MerchantId);
                throw new CustomValidationException(new[] { "MerchantId inválido. Certifique-se de que é um GUID válido." });
            }
        }
    }
}
