using Application.DTOS;
using Application.Exceptions;
using Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetMerchantsQueryHandler : IQueryHandler<GetMerchantsQuery, List<MerchantSummary>>
    {
        private readonly ILogger<GetMerchantsQueryHandler> _logger;
        private IComercioRepositorio comercioRepositorio;
        public GetMerchantsQueryHandler(ILogger<GetMerchantsQueryHandler> logger, IComercioRepositorio comercioRepositorio)
        {
            _logger = logger ?? throw new CustomValidationException(new[] {"Falha no Processamento"});
            this.comercioRepositorio = comercioRepositorio ?? throw new CustomValidationException(new[] { "Falha no Processamento" });
        }
        public async Task<List<MerchantSummary>> Handle(GetMerchantsQuery query)
        {
            _logger.LogInformation(">>> Consultando todas as Lojas do Usuário.");
             
            var result = await comercioRepositorio.ObterTodosComerciosAsync(query.UserId);
           
            try
            {
                
                if (result == null || !result.Any())
                {
                    _logger.LogWarning(">>> Nenhuma loja encontrada.");
                    return new List<MerchantSummary>();
                }
                var entityDto = result.Select(c => new MerchantSummary
                {
                    Id = c.UUID.ToString(),
                    Name = c.Nome,
                    CorporateName = c.NomeFantasia,
                }).ToList();
                // Simulate fetching merchants from a data source.

                _logger.LogInformation(">>> Lojas do Usuário Consultadas com Sucesso.");

                return entityDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar lojas do usuário.");
                throw new CustomValidationException(new[] { "Erro ao consultar lojas do usuário." });
            }
    }

}
}
