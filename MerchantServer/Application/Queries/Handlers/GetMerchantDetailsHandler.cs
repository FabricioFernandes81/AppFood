using Application.DTOS;
using Application.Exceptions;
using Azure.Core;
using Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetMerchantDetailsHandler : IQueryHandler<GetMerchantDetailsQuery, MerchantDetailsDto>
    {
        private readonly ILogger<GetMerchantDetailsHandler> _logger;
        private readonly IComercioRepositorio _comercioRepositorio;
       
        public GetMerchantDetailsHandler(ILogger<GetMerchantDetailsHandler> logger, IComercioRepositorio comercioRepositorio)
        {
            _logger = logger ?? throw new CustomValidationException(new[] { "Falha no Processamento" });
            _comercioRepositorio = comercioRepositorio ?? throw new ArgumentNullException(nameof(comercioRepositorio), "Comercio repository cannot be null");
        }


        public async Task<MerchantDetailsDto> Handle(GetMerchantDetailsQuery query)
        {
          
            _logger.LogInformation(">>> Consultando Loja {LojaId}.", query.MerchantId);
            

            var result = await _comercioRepositorio.ObterComercioPorIdAsync(query.MerchantId, query.UserId);

            try
            {
                if( result == null)
                {
                    _logger.LogWarning(">>> Loja não encontrada.");
                    return new MerchantDetailsDto();
                }
                var entityDto = new MerchantDetailsDto
                {
                    Id = result.UUID.ToString(),
                    Name = result.NomeFantasia,
                    Description = result.Descricao,
                    Type = result.Tipo.ToString(),
                    Address = $"{result.Endereco.Logradouro}, {result.Endereco.Numero}, {result.Endereco.Bairro}," +
                    $"{result.Endereco.Pais}",
                    Complement = result.Endereco?.Complemento,
                    shortAddress = $"{result.Endereco.Logradouro}, {result.Endereco.Numero}",
                    DeliveryPhone = result.TelefoneEntrega, //Funçao FormatarTelefone(result.TelefoneEntrega),
                    OwnerPhone = "99999999999",
                    MinimumOrderValue = new MinOrderDto
                    {
                        Currency = "BR",
                        Value = 10.50
                    },
                    Location = new LocationDto
                    {
                        Latitude = result.Endereco.Latitude,
                        Longitude = result.Endereco.Longitude,
                    },
                    Logo = null,
                    Country = result.Endereco.Pais,
                    State = result.Endereco.Estado,
                    City = result.Endereco.Cidade,
                    District = result.Endereco.Bairro,
                    Cover = null,
                    Email = "",
                    UUID = result.UUID.ToString(),
                    mainCuisine = result.Cozinha?.Code,
                };
                _logger.LogInformation(">>> Loja Consultada com Sucesso.");
                return entityDto;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro ao consultar loja");
                throw new CustomValidationException(new[] { "Erro ao consultar loja" });
            }


            

        }
    }
}
