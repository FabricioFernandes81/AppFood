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
    public class GetCuisinesHandler : IQueryHandler<GetCuisinesQuery, List<CuisinesDto>>
    {
        private readonly ILogger<GetCuisinesHandler> _logger;
        private readonly ICozinhaRepositorio _cozinhaRepositorio;

        public GetCuisinesHandler(ILogger<GetCuisinesHandler> logger, ICozinhaRepositorio cozinhaRepositorio)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null");
            _cozinhaRepositorio = cozinhaRepositorio ?? throw new ArgumentNullException(nameof(cozinhaRepositorio), "Cozinha repository cannot be null");
        }

        public async Task<List<CuisinesDto>> Handle(GetCuisinesQuery query)
        {
            _logger.LogInformation(">>> Consultando Cozinhas disponíveis.");

            var result = await _cozinhaRepositorio.GetCuisinesAsync();

            try
            {
                if (result == null || !result.Any())
                {
                    _logger.LogWarning(">>> Nenhuma Cozinha encontrada.");
                    return new List<CuisinesDto>();
                }
                var cuisinesDto = result.Select(c => new CuisinesDto
                {
                    Name = c.Name,
                    Code = c.Code,
                    
                }).ToList();
                _logger.LogInformation(">>> Cozinhas Consultadas com Sucesso.");
                return cuisinesDto;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro ao consultar Cozinhas");
                throw new CustomValidationException(new[] { "Erro ao consultar Cozinhas" });
            }

        }
    }
}
