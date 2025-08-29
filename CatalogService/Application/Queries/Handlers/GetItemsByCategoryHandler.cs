using Application.DTOS.items;
using Application.DTOS.Options;
using Application.DTOS.optionsGrup;
using Application.Exceptions;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetItemsByCategoryHandler : IQueryHandler<GetItemsByCategoryQuery, ItemDto>
    {
        private readonly ILogger<GetItemsByCategoryHandler> _logger;
        private readonly IItemRepository _itemRepository;

        public GetItemsByCategoryHandler(ILogger<GetItemsByCategoryHandler> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        public async Task<ItemDto> Handle(GetItemsByCategoryQuery query)
        {
            ItemDto response = new ItemDto();


            if (Guid.TryParse(query.CategoryId, out Guid categoryGuid) && Guid.TryParse(query.OwnerId, out Guid ownerId))
            {
                _logger.LogInformation(">>> Consultando Itens da Categoria com Id: {categoryId}", query.CategoryId);

                var items = await _itemRepository.GetItemsByCategoryAsync(categoryGuid,ownerId);
  
                response.Total = items.Count;
                
                var rows = items.Select(it=> new GetItemDto
                {
                    Id = it.ItemId.ToString(),
                    Name = it.Produto.Nome,
                    Availability = "ALWAYS", //Disponibilidade do item
                    optionGroup = it.Produto.ProdutoOpcoesGrupo != null ? it.Produto.ProdutoOpcoesGrupo.Select(og => new OptionGroupDto
                    {
                        Id = og.GrupoOpcoes.OpcaoGrupoId.ToString(),
                        Name = og.GrupoOpcoes.Nome,
                        Min = og.GrupoOpcoes.Min,
                        Max = og.GrupoOpcoes.Max,
                        Type = og.GrupoOpcoes.ResourceGroupoType.ToString(),
                        Status = og.GrupoOpcoes.Status.ToString(),
                        IsShared = false,
                        Fractions = null,
                        Options = og.GrupoOpcoes.Opcoes != null ? og.GrupoOpcoes.Opcoes.Select(o => new OptionDto
                        {
                            Id = o.OpcaoId.ToString(),
                            ProductId = o.Produto.ProdutoId.ToString(),
                            Name = o.Produto.Nome,
                            Status = o.Status.ToString(),
                            Fraction = o.Fracoes,
                            contextModifiers = o.Context != null ? o.Context.Select(c => new OptionContextModifierDto
                            {
                                parentOptionId = c.Opcao.OpcaoId.ToString(),
                                Status = c.Status.ToString(),

                            }).ToList() : new List<OptionContextModifierDto>(),

                        }).ToList() : new List<OptionDto>(),    
                    }).ToList() : new List<OptionGroupDto>(),
                    CategoryId = it.Categoria.CategoriaId.ToString(),
                    ProductId = it.Produto.ProdutoId.ToString(),
                    Description = it.Produto.Descricao,
                    Hasviolation = false,
                    IsIndustrialized = it.Produto.IsIndustrializado,
                    Problems = null,
                    Status = it.Produto.Status.ToString(),
                    Type = it.Tipo.ToString(),
                    
                }).ToList();


                response.Rows = rows;

                return response;


                

            }
            else { 

                _logger.LogError(">>> O ID da categoria fornecido é inválido: {categoryId}", query.CategoryId);

                throw new CustomValidationException(new [] { "O ID da categoria fornecido é inválido.",query.CategoryId});

            }

            




        }
    }
}
