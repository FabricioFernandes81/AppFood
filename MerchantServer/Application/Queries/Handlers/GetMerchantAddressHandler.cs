using Application.DTOS;
using Application.Exceptions;
using Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetMerchantAddressHandler : IQueryHandler<GetMerchantAddressQuery, AddressDto>
    {
        private readonly ILogger<GetMerchantAddressHandler> _logger;
        private readonly IComercioRepositorio _comercioRepositorio;

        public GetMerchantAddressHandler(ILogger<GetMerchantAddressHandler> logger, IComercioRepositorio comercioRepositorio)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null");
            _comercioRepositorio = comercioRepositorio ?? throw new ArgumentNullException(nameof(comercioRepositorio), "Comercio repository cannot be null");
        }
        public async Task<AddressDto> Handle(GetMerchantAddressQuery query)
        {
            var result = await _comercioRepositorio.ObterComercioPorIdAsync(query.MerchantId, query.UserId);
            
            if (result == null)
            {
                _logger.LogWarning(">>> Merchant not found for ID: {MerchantId}", query.MerchantId);
                return new AddressDto();
            }

            try
            {
                var addressDto = new AddressDto
                {
                    ZipCode = result.Endereco.CEP,
                    StreetNumber = result.Endereco.Numero,
                    Adress = result.Endereco.Logradouro,
                    City = result.Endereco.Cidade,
                    District = result.Endereco.Bairro,
                    Reference = result.Endereco.Referencia,
                    State = result.Endereco.Estado,
                    Country = result.Endereco.Pais,
                    Complement = result.Endereco.Complemento,
                    Latitude = result.Endereco.Latitude,
                    Longitude = result.Endereco.Longitude
                };

                return addressDto;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro ao consultar loja");
                throw new CustomValidationException(new[] { "Erro ao consultar loja" });

            }

        }
    }
}
