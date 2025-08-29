using Azure.Core;
using Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class UpdateMerchantsCommandHandler : ICommandHandler<UpdateMerchantsCommand>
    {
        public readonly ILogger<UpdateMerchantsCommandHandler> _logger;
        public readonly IComercioRepositorio _comercioRepositorio;
        public UpdateMerchantsCommandHandler(ILogger<UpdateMerchantsCommandHandler> logger, IComercioRepositorio comercioRepositorio)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null");
            _comercioRepositorio = comercioRepositorio ?? throw new ArgumentNullException(nameof(comercioRepositorio), "Comercio repository cannot be null");
        }

        public async Task Handle(UpdateMerchantsCommand command)
        {
            _logger.LogInformation(">>> Processando atualização da loja {ProductId}.", command.Id);
            var existingMerchant = await _comercioRepositorio.ObterComercioPorIdAsync(command.Id, command.UsersId);

            if (existingMerchant is null)
            {
                _logger.LogWarning(">>> Loja não encontrada para atualização.");
                return;
            }
            try
            {
                existingMerchant.NomeFantasia = command.Name;
                existingMerchant.Descricao = command.Description;
               existingMerchant.CozinhaCode = command.MainCuisine;
                existingMerchant.TelefoneEntrega = command.DeliveryPhone;


                await _comercioRepositorio.UpdateComercioAsync(existingMerchant);

                _logger.LogInformation(">>> Loja atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar loja");


            }
        }
    }
}
