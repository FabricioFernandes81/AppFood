using Application.DTOS.items;
using Application.DTOS.Options;
using Application.DTOS.optionsGrup;
using Application.Exceptions;
using Domain.Entities;
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

        List<OptionContextModifierDto> contextModifiers = new List<OptionContextModifierDto>();

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

                var items = await _itemRepository.GetItemsByCategoryAsync(categoryGuid, ownerId);

                response.Total = items.Count;

                var rows = items.Select(it=> new GetItemDto
                {
                    Id = it.ItemId.ToString(),
                    Name = it.Produto.Nome.ToString(),
                    Availability = "ALWAYS",
                    CategoryId = it.CategoriaId.ToString(),
                    ProductId = it.Produto.ProdutoId.ToString(),
                    Description = it.Produto.Descricao,
                    Hasviolation = false,
                    IsIndustrialized = it.Produto.IsIndustrializado,
                    Problems = null,
                    Status = it.Produto.Status.ToString(),
                    Tags = new string[] {},
                    Type = it.Tipo.ToString(),
                    StatusByCatalog = null,
                    
                    optionGroup = it.Produto.ProdutoOpcoesGrupo !=null ? it.Produto.ProdutoOpcoesGrupo.Select(og=> new OptionGroupDto
                    {
                        Id = og.GrupoOpcoes.OpcaoGrupoId.ToString(),
                        Name = og.GrupoOpcoes.Nome,
                        Min = og.GrupoOpcoes.Min,
                        Max = og.GrupoOpcoes.Max,
                        Order = 0,
                        Sequence = 0,
                        IsShared = false,
                        Type = og.GrupoOpcoes.Status.ToString(),
                        Status = og.GrupoOpcoes.Status.ToString(),
                        Fractions = null,
                        Options = og.GrupoOpcoes.Opcoes !=null ? og.GrupoOpcoes.Opcoes.Select(op=> new OptionDto
                        {
                            Id = op.OpcaoId.ToString(),
                            Name = op.Produto.Nome.ToString(),
                            ProductId = op.ProdutoId.ToString(),
                            Status = op.Status.ToString(),
                            Fraction = op.Fracoes,
                            StatusByCatalogs = new List<StatusByCatalog>
                            {

                            },
                         
                        }).ToList() : new List<OptionDto>(),

                    }).ToList() : new List<OptionGroupDto>(),
                    
                }).ToList();

            /*    var rows = items.Select(it => new GetItemDto
                {
                    Id = it.ItemId.ToString(),
                    Name = it.Produto.Nome,
                    Availability = "ALWAYS",
                    optionGroup = it.Produto.ProdutoOpcoesGrupo?
                      .Select(og => new OptionGroupDto
                      {
                          Id = og.GrupoOpcoes.OpcaoGrupoId.ToString(),
                          Name = og.GrupoOpcoes.Nome,
                          Min = og.GrupoOpcoes.Min,
                          Max = og.GrupoOpcoes.Max,
                          Type = og.GrupoOpcoes.ResourceGroupoType.ToString(),
                          Status = og.GrupoOpcoes.Status.ToString(),
                          IsShared = false,
                          Fractions = null,
                          Options = og.GrupoOpcoes.Opcoes != null
                              ? MapOptions(og.GrupoOpcoes.Opcoes)
                              : new List<OptionDto>()
                      })
                      .ToList() ?? new List<OptionGroupDto>(),

                    CategoryId = it.Categoria.CategoriaId.ToString(),
                    ProductId = it.Produto.ProdutoId.ToString(),
                    Description = it.Produto.Descricao,
                    Hasviolation = false,
                    IsIndustrialized = it.Produto.IsIndustrializado,
                    Problems = null,
                    Status = it.Produto.Status.ToString(),
                    StatusByCatalog = it.Produto.CatalogoStatus?
                      .Select(st => new StatusByCatalog
                      {
                          Status = st.Status.ToString(),
                          CatalogId = st.Catalogo.CatalogoId.ToString(),
                          CatalogType = st.Catalogo.Tipo.ToString(),
                          Available = true,
                            
                          
                      })
                      
                      .ToList() ?? new List<StatusByCatalog>(),
                    Type = it.Tipo.ToString(),
                }).ToList();
            */


                response.Rows = rows;

                return response;




            }
            else
            {

                _logger.LogError(">>> O ID da categoria fornecido é inválido: {categoryId}", query.CategoryId);

                throw new CustomValidationException(new[] { "O ID da categoria fornecido é inválido.", query.CategoryId });

            }






        }
       

        private static List<OptionDto> MapOptions(List<Opcoes> opcoes)
        {
            /*  return opcoes.Select(opcao => new OptionDto
              {
                  Id = opcao.OpcaoId.ToString(),
                  ProductId = opcao.Produto.ProdutoId.ToString(),
                  Name = opcao.Produto.Nome,
                  Status = opcao.Status.ToString(),
                  Fraction = opcao.Fracoes,

                  contextModifiers = opcao.contextos?
                      .Select(c => new OptionContextModifierDto
                      {
                          parentOptionId = c.Opcao.OpcaoId.ToString(),
                          Status = c.Status.ToString(),
                          StatusByCatalog = c.CatalogoStatus?
                              .Select(st => new StatusByCatalog
                              {
                                  Status = st.Status.ToString(),
                                  CatalogId = st.Catalogo.CatalogoId.ToString(),
                                  CatalogType = st.Catalogo.Tipo.ToString(),
                                  Available = true,
                              })
                              .ToList() ?? new List<StatusByCatalog>(),
                      })
                      .ToList() ?? new List<OptionContextModifierDto>(),



              }).ToList();*/
            return null;
        }
    }
}
