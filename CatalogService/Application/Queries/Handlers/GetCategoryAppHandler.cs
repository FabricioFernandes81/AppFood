using Application.DTOS.catalog;
using Application.DTOS.categories;
using Application.DTOS.items;
using Application.Exceptions;
using Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetCategoryAppHandler : IQueryHandler<GetCategoryAppQuery, List<GetCategoryAppDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<GetCategoryAppHandler> _logger;

        public GetCategoryAppHandler(ICategoryRepository repository, ILogger<GetCategoryAppHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<GetCategoryAppDto>> Handle(GetCategoryAppQuery query)
        {
            _logger.LogInformation(">>> Consultando categoria com o Catalogo ID: {CatalogoId} para o comerciante com ID: {MerchantId}", query.CatalogId, query.MerchantId);

            if (Guid.TryParse(query.MerchantId, out var merchantId) && Guid.TryParse(query.CatalogId, out var catalogid))
            {
                var result = await _repository.GetCategoriesAsync(merchantId,catalogid, query.IncludeItems);

                if (result == null || !result.Any()) 
                {
                    _logger.LogWarning(">>> Nenhuma categoria encontrada para o comerciante com ID: {MerchantId}", query.MerchantId);
                    return new List<GetCategoryAppDto>();
                }
                List<GetCategoryAppDto> response = result.Select(cat=>new GetCategoryAppDto
                {
                    Id = cat.CategoriaId.ToString(),
                    Name = cat.Nome,
                    Index = cat.Index,
                    Seqsuence = 0,
                    Status = cat.Status.ToString(),
                    Template = cat.Tipo.ToString(),
                    Items = cat.Items != null ? cat.Items.Select(it=> new GetItemAppDto
                    {
                        Id = it.ItemId.ToString(),
                        Nome = it.Produto.Nome,
                        Descricao = it.Produto.Descricao,
                        ProductId = it.ProdutoId.ToString(),
                        Status = it.Produto.Status.ToString(),
                        OptionGroups = it.Produto.ProdutoOpcoesGrupo !=null ? it.Produto.ProdutoOpcoesGrupo.Select((op,index)=> new optionGroupsAppDto
                        {
                            Id = op.GrupoId.ToString(),
                            Nome = op.GrupoOpcoes.Nome,
                            Min = op.GrupoOpcoes.Min,
                            Max = op.GrupoOpcoes.Max,
                            Sequence = op.GrupoOpcoes.Index,
                            Index = index,
                            Status = op.GrupoOpcoes.Status.ToString(),
                            Options = op.GrupoOpcoes.Opcoes != null ? op.GrupoOpcoes.Opcoes.Select((o,index)=> new OptionsAppDto
                            {
                                Id = o.OpcaoId.ToString(),
                                Name = o.Produto.Nome,
                                Descricao = o.Produto.Descricao,
                                Status = o.Produto.Status.ToString(),
                                Index = index,
                                ProductId = o.Produto.ProdutoId.ToString(),
                                Sequence = 0,

                            }).ToList() : new List<OptionsAppDto>(),

                        }).ToList() : new List<optionGroupsAppDto>(),
                        
                        contextModifiers = it.ContextoItems !=null ? it.ContextoItems.Select(cm=> new ContextModifiersDto
                        {
                            CatalogContext = cm.ContextoType.ToString(),
                            ItemContextId = cm.ItemId.ToString(),
                        }).ToList() : new List<ContextModifiersDto>(),

                        CustomizationModifiers = it.CustomizacaoModificacoes != null ? it.CustomizacaoModificacoes
                        .Select( cus=> new customizationModifiersDto { 
                            Id = cus.Id.ToString(),
                            CustomizationOptionId = cus.customizationOptionId.ToString(),
                            ParentCustomizationOptionId = cus.parentCustomizationOptionId.ToString(),
                            Status = cus.Status.ToString()

                            }).ToList() : new List<customizationModifiersDto>(),

                    }).ToList():new List<GetItemAppDto> (),

                }).ToList();
                    
                

                return response;

            }
            else 
            {
                _logger.LogError(">>> O IDs fornecidos são inválidos");
                throw new CustomValidationException(new[] { $"Produto com ID {query.MerchantId} não encontrado ou " });
                return new List<GetCategoryAppDto>();
            }

              
        }
    }
}
