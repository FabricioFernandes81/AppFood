using Domain.Entities;
using Domain.Enuns;
using Infrastructure.Configurations.TablesConfigurations;
using Infrastructure.Repositories;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class PutOptionStatusHandler : ICommandHandler<PutOptionStatusCommand>
    {
        private readonly ILogger<PutOptionStatusHandler> _logger;
        private readonly IItemRepository _itemRepository;
        public PutOptionStatusHandler(ILogger<PutOptionStatusHandler> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }
        public async Task Handle(PutOptionStatusCommand command)
        {
            _logger.LogInformation(">>> Editando Status das Opções do Merchant com Id: {merchantId}", command.MerchantId);
            if (command.MerchantId == null) { 
                _logger.LogError("MerchantId é nulo.");
            }
            else
            {
                if (Guid.TryParse(command.MerchantId, out Guid merchantGuid))
                {
                    _logger.LogInformation(">>> MerchantId é válido: {merchantId}", command.MerchantId);
               /*     var existingOption = await _itemRepository.GetOpcaoByIdAsync(Guid.Parse(command.Id));

                    // Check if the option exists and has contexts to update.
                    if (existingOption == null || existingOption.contextos == null)
                    {
                        return;
                    }

                    // 2. Iterate through the existing contexts directly.
                    foreach (var existingContexto in existingOption.contextos)
                    {
                        // 3. Find the corresponding data in the command's statusByCatlogs.
                      /*  var commandStatus = command.StatusByCatlogs
                            .FirstOrDefault(cs => cs.CatalogId == existingContexto.Id);*/

                    /*    if (commandStatus != null)
                        {
                            // 4. Update the properties of the existing contexts.
                            existingContexto.Status = (ResourceStatus)Enum.Parse(typeof(ResourceStatus), commandStatus.Status, true);

                            // 5. Update the nested catalog statuses.
                            foreach (var existingCatalogoStatus in existingContexto.CatalogoStatus)
                            {
                                var newStatusData = commandStatus.StatusByCatlogs.FirstOrDefault(cs => cs.CatalogoId == existingCatalogoStatus.CatalogoId);

                                if (newStatusData != null)
                                {
                                    existingCatalogoStatus.Status = (ResourceStatus)Enum.Parse(typeof(ResourceStatus), newStatusData.Status, true);
                                }
                            }
                        }
                    }
                    // existingOption.Status = (ResourceStatus)Enum.Parse(typeof(ResourceStatus), command.Status, true);


                    /*  CatalogoStatus catalogo = new CatalogoStatus
                      {
                          Id = item.Id,
                          ProdutoId = item.ProdutoId,
                          ContextoId = item.ContextoId,
                          CatalogoId = item.CatalogoId,
                          DataCriacao = item.DataCriacao,
                          Status = item.Status == ResourceStatus.AVAILABLE 
                          ? ResourceStatus.UNAVAILABLE : ResourceStatus.AVAILABLE,

                      };

                      _logger.LogInformation("Item {OptionId}", catalogo);

                      catalogos.Add(catalogo);*/

                }

                        // Se quiser atualizar o restante do contexto, pode chamar UpdateContexto aqui
                       
                   // }
                        _logger.LogInformation(">>> Opção {OptionId} atualizado com sucesso.", command.Id);
                
            }


        }
    }
}
