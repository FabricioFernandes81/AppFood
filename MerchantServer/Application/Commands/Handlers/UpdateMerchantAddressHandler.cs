using Domain.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class UpdateMerchantAddressHandler : ICommandHandler<UpdateMerchantAddressCommand>
    {
        private readonly ILogger<UpdateMerchantAddressHandler> _logger;
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public UpdateMerchantAddressHandler(ILogger<UpdateMerchantAddressHandler> logger, IEnderecoRepositorio enderecoRepositorio)
        {
            _logger = logger;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task Handle(UpdateMerchantAddressCommand command)
        {
            _logger.LogInformation(">>> Processando atualização da loja {ProductId}.", command.MerchantId);
            var existingAddress = await _enderecoRepositorio.EnderecoById(command.MerchantId,command.UsersId);
             if (existingAddress is null)
            {
                _logger.LogWarning(">>> Endereço não encontrado para atualização.");
                return;
            }
            try
            {
                existingAddress.Logradouro = command.Street;
                existingAddress.Numero = command.Number;
                
                existingAddress.Complemento = command.Complement;
                existingAddress.Bairro = command.Ditrict;
                existingAddress.Cidade = command.City;
                existingAddress.Estado = command.State;
                existingAddress.CEP = command.ZipCode.Replace("-","").Trim();
                existingAddress.Pais = command.Country;
                existingAddress.Latitude = command.Latitude;
                existingAddress.Longitude = command.Longitude;

                _logger.LogInformation(">>> Atualizando endereço para a loja {MerchantId}.", command.MerchantId);
                await _enderecoRepositorio.UpdateEndereco(existingAddress);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro ao atualizar o endereço");
            }
           
        }
    }
}
