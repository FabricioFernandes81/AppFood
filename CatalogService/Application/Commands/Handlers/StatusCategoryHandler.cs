

using Application.DTOS;
using Application.Exceptions;
using Domain.Entities;
using Domain.Enuns;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Commands.Handlers
{
    public class StatusCategoryHandler : ICommandHandler<StatusCategoryCommand>
    {
       private readonly ILogger<StatusCategoryHandler> logger;
       private ICategoryRepository categoryRepository;


        public StatusCategoryHandler(ILogger<StatusCategoryHandler> logger, ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }

        public async Task Handle(StatusCategoryCommand command)
        {
            if (!Guid.TryParse(command.MerchantId, out var merchantId) ||
              !Guid.TryParse(command.CatagoryId, out var categoryId))
            {
                this.logger.LogError(">>> Os IDs fornecidos são inválidos");
                throw new CustomValidationException(new[] { $"Categoria com ID {command.CatagoryId} não encontrado ou inválido." });
            }

            var existingCategory = await this.categoryRepository.GetCategoryByIdAsync(categoryId, merchantId);
            if (existingCategory is null)
            {
                this.logger.LogWarning("Category with ID {CategoryId} not found", command.CatagoryId);
                return;
            }

            ResourceStatus result;

            switch (command.Status?.ToLowerInvariant())
            {
                case "enable":
                    result = ResourceStatus.AVAILABLE;
                    break;
                case "disable":
                    result = ResourceStatus.UNAVAILABLE;
                    break;
                default:
                    this.logger.LogWarning(">>> Status inválido: {Status}", command.Status);
                    return;
            }

            existingCategory.Status = result;

            // Aqui você pode salvar a alteração, se necessário:
             await this.categoryRepository.UpdateCategoryAsync(existingCategory);

            return;


        }
    }
}
