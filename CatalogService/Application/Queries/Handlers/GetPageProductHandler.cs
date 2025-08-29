using Application.DTOS.categories;
using Application.DTOS.product;
using Application.Exceptions;
using Domain.Entities;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Handlers
{
    public class GetPageProductHandler : IQueryHandler<GetPageProductQuery, GetProductResponseDto>
    {
        private readonly ILogger<GetPageProductHandler> _logger;
        private readonly IProductRepository _productRepository;
        public GetPageProductHandler(ILogger<GetPageProductHandler> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;

        }
        public async Task<GetProductResponseDto> Handle(GetPageProductQuery query)
        {
            if (Guid.TryParse(query.MerchantId, out Guid merchantGuid))
            {
                GetProductResponseDto responseDto = new GetProductResponseDto();
                _logger.LogInformation(">>>Consultando Produtos disponiveis para o Comerciante com Id:{merchantId}", query.MerchantId);
                var produtResult = await _productRepository.GetPageAsync(query.Page, query.PageSize, merchantGuid);
                

                List<ProductDto> products = new List<ProductDto>();

                foreach (var product in produtResult)
                {
                    // Adiciona produtos das opções
                    foreach (var optionsGr in product.ProdutoOpcoesGrupo)
                    {
                        foreach (var options in optionsGr.GrupoOpcoes.Opcoes)
                        {
                            ProductDto optionDto = new ProductDto
                            {
                                Id = options.ProdutoId.ToString(),
                                Name = options.Produto.Nome,
                                Description = options.Produto.Descricao,
                                Status = options.Produto.Status.ToString(),
                                OfferTypes = new List<string> { "OPTIONS" },
                                    availableAt = new List<AvailableAt>
                                    {
                                        new AvailableAt
                                        {
                                            Id = optionsGr.GrupoOpcoes.Id.ToString(),
                                            Name = optionsGr.GrupoOpcoes.Nome,
                                            Status = optionsGr.GrupoOpcoes.Status.ToString(),
                                        }
                                    }
                                                };

                            products.Add(optionDto);
                        }
                    }

                    // Adiciona o produto principal (item)
                    ProductDto itemDto = new ProductDto
                    {
                        Id = product.Id.ToString(),
                        Name = product.Nome,
                        Description = product.Descricao,
                        Status = product.Status.ToString(),
                        Unit = product.Unidade,
                        Quantity = product.Peso,
                        OfferTypes = new List<string> { "ITEM" },
                        availableAt = new List<AvailableAt>
                            {
                                new AvailableAt
                                {
                                    Id = product.Items.Categoria.Id.ToString(),
                                    Name = product.Items.Categoria.Nome,
                                    Status = product.Items.Categoria.Status.ToString(),
                                }
                            }
                    };

                    products.Add(itemDto);
                }



                responseDto.Data = products;
                responseDto.Page = query.Page;
                responseDto.Offset = (query.Page - 1) * query.PageSize;
                responseDto.Total = produtResult.Count();
                responseDto.Pages = (int)Math.Ceiling((double)responseDto.Total / query.PageSize);
                _logger.LogInformation(">>> Consulta finalizada com sucesso. Total de Produtos encontrados: {TotalProducts}", responseDto.Total);

                return responseDto;


            }
            else
            {
                _logger.LogError(">>> Falha ao converter o ID do comerciante: {MerchantId} para GUID", query.MerchantId);
                throw new CustomValidationException(new[] { "MerchantId inválido. Certifique-se de que é um GUID válido." });

            }

        }
    }
}
