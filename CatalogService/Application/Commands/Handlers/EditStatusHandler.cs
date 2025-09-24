using Application.DTOS.items;
using Azure.Core;
using Domain.Entities;
using Domain.Enuns;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class EditStatusHandler : ICommandHandler<PutItemStatusCommand>
    {
        private readonly ILogger<EditStatusHandler> _logger;
        private readonly IItemRepository _itemRepository;
        public EditStatusHandler(ILogger<EditStatusHandler> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        public async Task Handle(PutItemStatusCommand command)
        {
            _logger.LogInformation(">>> Editando Status dos Itens do Merchant com Id: {merchantId}", command.MerchantId);
         /*   if (command.MerchantId == null)
            {
                _logger.LogError("MerchantId é nulo.");
                throw new ArgumentNullException(nameof(command.MerchantId), "MerchantId não pode ser nulo.");
            }
            else if (Guid.TryParse(command.MerchantId, out Guid merchantGuid))
            {
                _logger.LogInformation(">>> MerchantId é válido: {merchantId}", command.MerchantId);

                var existingItem = await _itemRepository.GetItemsByIdsAsync(Guid.Parse(command.Id), merchantGuid);
                if (existingItem is null)
                {
                    return;
                }
                existingItem.Status = (ResourceStatus)Enum.Parse(typeof(ResourceStatus), command.Status, true);
                await _itemRepository.UpdateAsync(existingItem);
             
                foreach (var statusByCatlog in command.StatusByCatlogs)
                {
                    var existingStatus = await _itemRepository.GetSatusCatalogoById(Guid.Parse(statusByCatlog.CatalogId), existingItem.ProdutoId);
                    if (existingStatus is null)
                    {
                        _logger.LogWarning("Status do Catálogo com Id: {catalogId} não encontrado para o Produto com Id: {productId}", statusByCatlog.CatalogId, existingItem.ProdutoId);
                        continue;
                    }
                    existingStatus.Status = (ResourceStatus)Enum.Parse(typeof(ResourceStatus), statusByCatlog.Status, true);
                    await _itemRepository.UpdateStatusCatalogoAsync(existingStatus);
                }*/

                _logger.LogInformation(">>> Produto {ProductId} atualizado com sucesso.", command.Id);
            }
        }
    }

