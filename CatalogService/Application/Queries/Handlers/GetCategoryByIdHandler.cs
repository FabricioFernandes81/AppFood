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
    public class GetCategoryByIdHandler : IQueryHandler<GetCategoryByIdQuery, GetCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<GetCategoryByIdHandler> _logger;


        public GetCategoryByIdHandler(ICategoryRepository categoryRepository, ILogger<GetCategoryByIdHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<GetCategoryDto> Handle(GetCategoryByIdQuery query)
        {
          _logger.LogInformation(">>> Consultando categoria com ID: {CategoryId} para o comerciante com ID: {MerchantId}", query.CategoryId, query.MerchantId);
            string categoryId = query.CategoryId?.Trim();
            string merchantId = query.MerchantId?.Trim();
            if (Guid.TryParse(categoryId, out Guid categoryGuid) && Guid.TryParse(merchantId, out Guid merchantGuid))
            {
              
                return null;
            }
            else
            {
                _logger.LogError(">>> Falha ao converter o ID da categoria: {CategoryId} ou do comerciante: {MerchantId} para GUID", query.CategoryId, query.MerchantId);
                throw new CustomValidationException(new[] { "CategoryId ou MerchantId inválidos. Certifique-se de que são GUIDs válidos." });
            }
        }
    }
}
