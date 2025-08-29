using Application.DTOS;
using Application.Exceptions;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CreateCategoryHandler> _logger;
        private readonly ICatalogRepository  _catalogRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryHandler> logger, ICatalogRepository catalogRepository)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _catalogRepository = catalogRepository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            if (Guid.TryParse(command.MerchantId, out Guid merchantGuid))
            {

       
            }
            else
            {
                _logger.LogError(">>> Falha ao converter o ID do comerciante: {MerchantId} para GUID", command.MerchantId);
                throw new CustomValidationException(new[] { "MerchantId inválido. Certifique-se de que é um GUID válido." });
            }
        }
    }
}
