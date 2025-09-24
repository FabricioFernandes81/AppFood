
using Domain.Entities;
using Domain.Juncoes;
using Infrastructure.Configurations;
using Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextCatalogs _context;

        public CategoryRepository(ContextCatalogs context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetCategoriesAsync(Guid merchantId)
        {
               var entityCategories = await _context.Categorias
                   .Where(c => c.Catalogo.ComercioId == merchantId)
                   .Include(c => c.Items)
                   .AsNoTracking()
                   .ToListAsync();
               return entityCategories;
            
        }

        public async Task<List<Categoria>> GetCategoriesAsync(Guid merchantId, Guid catalogId, bool includeItems)
        {
            var query =  _context.Categorias
                .Where(cat => cat.CatalogoId == catalogId || cat.Catalogo.ComercioId == merchantId);
            if (includeItems)
            {
                /* query = query.Include(cat => cat.Items)
                      .ThenInclude(c=>c.ContextoItems)
                      .Include(i=>i.Items)
                      .ThenInclude(co=>co.ContextoItems)
                      .Include(i=>i.Items)
                      .ThenInclude(item => item.Produto)
                      .ThenInclude(prod => prod.ProdutoOpcoesGrupo)
                      .ThenInclude(grupo => grupo.GrupoOpcoes)
                      .ThenInclude(op => op.Opcoes)
                      .ThenInclude(p => p.Produto);*/

                query = query.Select(ca => new Categoria
                {
                    CategoriaId = ca.CategoriaId,
                    Catalogo = ca.Catalogo,
                    CatalogoId = catalogId,
                    DataCriacao = ca.DataCriacao,
                    Descricao = ca.Descricao,
                    Index = ca.Index,
                    Nome = ca.Nome,
                    Status = ca.Status,
                    Tipo = ca.Tipo,
                    Items = ca.Items.Select(it=> new Item
                    {
                        ItemId = it.ItemId,
                        CategoriaId = it.CategoriaId,
                        Index = it.Index,
                        Tipo = it.Tipo,
                        DataCriacao = it.DataCriacao,
                        ProdutoId = it.ProdutoId,
                        
                        Produto = new Produto
                        {
                            ProdutoId = it.Produto.ProdutoId,
                            Serving = it.Produto.Serving,
                            Ean = it.Produto.Ean,
                            Status = it.Produto.Status,
                            Peso = it.Produto.Peso,
                            RestriocaoAlimentar = it.Produto.RestriocaoAlimentar,
                            Nome = it.Produto.Nome,
                            Unidade = it.Produto.Unidade,
                            Descricao = it.Produto.Descricao,
                            IsIndustrializado = it.Produto.IsIndustrializado,
                            DataCriacao = it.Produto.DataCriacao,
                            CatalogoId = it.Produto.CatalogoId,
                            ProdutoOpcoesGrupo = it.Produto.ProdutoOpcoesGrupo.Select(gp=> new ProdutoOpcoesGrupo
                            {
                                GrupoId = gp.GrupoId,
                                GrupoOpcoes = new GrupoOpcoes {
                                 OpcaoGrupoId = gp.GrupoOpcoes.OpcaoGrupoId,
                                 Min = gp.GrupoOpcoes.Min,
                                 Max = gp.GrupoOpcoes.Max,
                                 Nome = gp.GrupoOpcoes.Nome,
                                 Status = gp.GrupoOpcoes.Status,
                                 DataCriacao = gp.GrupoOpcoes.DataCriacao,
                                 Index = gp.GrupoOpcoes.Index,
                                 ResourceGroupoType = gp.GrupoOpcoes.ResourceGroupoType,
                                 Opcoes = gp.GrupoOpcoes.Opcoes.Select(op=> new Opcoes
                                 {
                                     OpcaoId = op.OpcaoId,
                                     Fracoes = op.Fracoes,
                                     Status = op.Status,
                                     ProdutoId = op.ProdutoId,
                                     OpcoesGrupoId = op.OpcoesGrupoId,
                                     Produto = new Produto 
                                     {
                                         ProdutoId = op.Produto.ProdutoId,
                                         Serving = op.Produto.Serving,
                                         Ean = op.Produto.Ean,
                                         Status = op.Produto.Status,
                                         Peso = op.Produto.Peso,
                                         RestriocaoAlimentar = op.Produto.RestriocaoAlimentar,
                                         Nome = op.Produto.Nome,
                                         Unidade = op.Produto.Unidade,
                                         Descricao = op.Produto.Descricao,
                                         IsIndustrializado = op.Produto.IsIndustrializado,
                                         DataCriacao = op.Produto.DataCriacao,
                                         CatalogoId = op.Produto.CatalogoId,

                                     },
                                     CustomizacaoModificacoes = op.CustomizacaoModificacoes.Select(cus=> new CustomizacaoModificacoes
                                     {
                                         Id = cus.Id,
                                         Status = cus.Status,
                                         customizationOptionId = cus.customizationOptionId,
                                         parentCustomizationOptionId = cus.parentCustomizationOptionId,
                                         ItemId = cus.ItemId,
                                         Item = cus.Item,
                                         
                                     }).ToList(),
                                      
                                 }).ToList(),
                                 
                                },
                                
                            }).ToList(),
                            
                        },
                        ContextoItems = it.ContextoItems,
                        CustomizacaoModificacoes = it.CustomizacaoModificacoes,
                    }).ToList(),
                    
                
                
                });
                   


            }
            var entity = await query
                            .AsNoTracking()
                            .ToListAsync();
               

            return entity;
        }

        public async Task<Categoria> GetCategoryByIdAsync(Guid categoryId, Guid merchantId)
        {
            var entityCategory = await _context.Categorias
                .Where(c => c.Catalogo.ComercioId == merchantId && c.CategoriaId == categoryId)
                .FirstOrDefaultAsync();

            return entityCategory;
        }

        public async Task<Categoria> UpdateCategoryAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;

        }
    }
}
