
using Domain.Entities;
using Domain.Enuns;
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
    public class ItemRepository : IItemRepository
    {
        private readonly ContextCatalogs _contextCatalogs;
        public ItemRepository(ContextCatalogs contextCatalogs)
        {
            _contextCatalogs = contextCatalogs;
        }




        public async Task<List<Item>> GetItemsByCategoryAsync(Guid category, Guid OwnerId)
        {

            var itemsEntity = await _contextCatalogs.Itens
                  .Where(c => c.Categoria.CategoriaId == category && c.Categoria.Catalogo.ComercioId == OwnerId)
                .AsNoTracking()

                .Select(it => new Item
                {
                    ItemId = it.ItemId,
                    Index = it.Index,
                    Tipo = it.Tipo,
                    ProdutoId = it.ProdutoId,
                    Produto = new Produto
                    {
                        ProdutoId = it.Produto.ProdutoId,
                        Nome = it.Produto.Nome,
                        Peso = it.Produto.Peso,
                        Descricao = it.Produto.Descricao,
                        Ean = it.Produto.Ean,
                        DataCriacao = it.Produto.DataCriacao,
                        IsIndustrializado = it.Produto.IsIndustrializado,
                        Status = it.Produto.Status,
                        Unidade = it.Produto.Unidade,
                        Serving = it.Produto.Serving,
                        RestriocaoAlimentar = it.Produto.RestriocaoAlimentar,
                        ProdutoOpcoesGrupo = it.Produto.ProdutoOpcoesGrupo.Select(po => new ProdutoOpcoesGrupo
                        {
                            GrupoId = po.GrupoId,
                            ProdutoId = po.Produto.ProdutoId,
                            GrupoOpcoes = new GrupoOpcoes
                            {
                                OpcaoGrupoId = po.GrupoOpcoes.OpcaoGrupoId,
                                Nome = po.GrupoOpcoes.Nome,
                                Index = po.GrupoOpcoes.Index,
                                Status = po.GrupoOpcoes.Status,
                                DataCriacao = po.GrupoOpcoes.DataCriacao,
                                Min = po.GrupoOpcoes.Min,
                                Max = po.GrupoOpcoes.Max,
                                ResourceGroupoType = po.GrupoOpcoes.ResourceGroupoType,

                                Opcoes = it.Tipo == ResourceItemTipo.PIZZA ?
                                po.GrupoOpcoes.Opcoes.Select(op => new Opcoes
                                {
                                    OpcaoId = op.OpcaoId,
                                    Status = op.Status,
                                    ProdutoId = op.ProdutoId,
                                    Produto = op.Produto,
                                }).ToList() : new List<Opcoes>()
                            }
                        }).ToList(),
                    },
                    CategoriaId = it.CategoriaId,
                    Categoria = it.Categoria,
                    DataCriacao = it.DataCriacao,


                })

                .ToListAsync();

            return itemsEntity;

            /*  var items = await _contextCatalogs.Itens
                  .Where(c => c.Categoria.CategoriaId == category && c.Categoria.ComercioUId == OwnerId)
                .AsNoTracking()
                  .Select(it=> new Item
                  {
                     
                      ItemId = it.ItemId,
                      Tipo = it.Tipo,
                      Index = it.Index,
                      DataCriacao = it.DataCriacao,
                      ProdutoId = it.ProdutoId,

                      Produto = new Produto
                      {
                         
                          ProdutoId = it.Produto.ProdutoId,
                          Nome = it.Produto.Nome,
                          Descricao = it.Produto.Descricao,
                          Status = it.Produto.Status,
                          IsIndustrializado = it.Produto.IsIndustrializado,
                          DataCriacao = it.Produto.DataCriacao,
                          Unidade = it.Produto.Unidade,
                          Peso = it.Produto.Peso,
                          ComercioUId = it.Produto.ComercioUId,
                          Serving = it.Produto.Serving,
                          RestriocaoAlimentar = it.Produto.RestriocaoAlimentar,
                          Ean = it.Produto.Ean,
                          CatalogoStatus = it.Produto.CatalogoStatus != null ? 
                          it.Produto.CatalogoStatus.Select(st=> new CatalogoStatus
                          {
                              Id = st.Id,
                              Status = st.Status,
                              ProdutoId = st.ProdutoId,
                              CatalogoId = st.CatalogoId,
                              DataCriacao = st.DataCriacao,
                              Catalogo = st.Catalogo,
                              Produto = st.Produto,

                          }).ToList() : new List<CatalogoStatus>(),
                          ProdutoOpcoesGrupo = it.Produto.ProdutoOpcoesGrupo != null ? it.Produto.ProdutoOpcoesGrupo


                          .Select(og=> new ProdutoOpcoesGrupo
                          {
                              GrupoId = og.GrupoId,
                              ProdutoId = og.ProdutoId,
                              GrupoOpcoes = new GrupoOpcoes 
                              {
                                 // Id=og.GrupoOpcoes.Id,
                                  Nome = og.GrupoOpcoes.Nome,
                                  Min = og.GrupoOpcoes.Min,
                                  Max = og.GrupoOpcoes.Max,
                                  Status = og.GrupoOpcoes.Status,
                                  DataCriacao = og.GrupoOpcoes.DataCriacao,
                                  Index = og.GrupoOpcoes.Index,
                                  ResourceGroupoType = og.GrupoOpcoes.ResourceGroupoType,
                                  OpcaoGrupoId = og.GrupoOpcoes.OpcaoGrupoId,
                                  Opcoes = (it.Tipo != Domain.Enuns.ResourceItemTipo.DEFAULT && og.GrupoOpcoes.Opcoes != null) ?
                                   og.GrupoOpcoes.Opcoes.Select(op=>new Opcoes
                                  {
                                    
                                      OpcaoId = op.OpcaoId,
                                      Status = op.Status,
                                      OpcoesGrupoId = op.OpcoesGrupoId,
                                      ProdutoId = op.ProdutoId,
                                      Fracoes = op.Fracoes,
                                      Produto = new Produto
                                      {
                                     
                                          Nome = op.Produto.Nome,
                                            ProdutoId = op.Produto.ProdutoId,
                                            Descricao = op.Produto.Descricao,
                                            Status = op.Produto.Status,
                                            IsIndustrializado = op.Produto.IsIndustrializado,
                                            DataCriacao = op.Produto.DataCriacao,
                                            Unidade = op.Produto.Unidade,
                                            Peso = op.Produto.Peso,
                                            ComercioUId = op.Produto.ComercioUId,
                                            Serving = op.Produto.Serving,
                                            RestriocaoAlimentar = op.Produto.RestriocaoAlimentar,
                                            Ean = op.Produto.Ean,
                                            CatalogoStatus = op.Produto.CatalogoStatus != null ? 
                                            op.Produto.CatalogoStatus.Select(st => new CatalogoStatus
                                            {
                                                Id = st.Id,
                                                Status = st.Status,
                                                ProdutoId = st.ProdutoId,
                                                CatalogoId = st.CatalogoId,
                                                DataCriacao = st.DataCriacao,
                                                Catalogo = st.Catalogo,

                                            }).ToList() : new List<CatalogoStatus>(),
                                      },

                                      Context = op.Context != null ? op.Context.Select(c=> new Contexto
                                      {
                                          Id = c.Id,
                                          ContextoId = c.ContextoId,
                                          Status = c.Status,
                                          OpcaoId = c.OpcaoId,
                                          Opcao = c.Opcao,
                                          CatalogoStatus = c.CatalogoStatus != null ? c.CatalogoStatus.Select(cs => new CatalogoStatus
                                          {
                                              Id = cs.Id,
                                              Status = cs.Status,
                                              ProdutoId = cs.ProdutoId,
                                              CatalogoId = cs.CatalogoId,
                                              DataCriacao = cs.DataCriacao,
                                              Catalogo = cs.Catalogo,
                                          }).ToList() : new List<CatalogoStatus>(),
                                      }).ToList() : new List<Contexto>(),
                                      contextos = op.contextos != null ? op.contextos.Select(c => new Contexto
                                      {
                                          Id = c.Id,
                                          ContextoId = c.ContextoId,
                                          Status = c.Status,
                                          parentOptionId = c.parentOptionId,
                                          ParentOption = c.ParentOption,
                                          OpcaoId = c.OpcaoId,
                                          CatalogoStatus = c.CatalogoStatus != null ? c.CatalogoStatus.Select(cs => new CatalogoStatus
                                          {
                                              Id = cs.Id,
                                              Status = cs.Status,
                                              ProdutoId = cs.ProdutoId,
                                              CatalogoId = cs.CatalogoId,
                                              DataCriacao = cs.DataCriacao,
                                              Catalogo = cs.Catalogo,
                                          }).ToList() : new List<CatalogoStatus>(),
                                          Opcao = new Opcoes
                                          {
                                             
                                              OpcaoId = c.Opcao.OpcaoId,
                                              Status = c.Opcao.Status,
                                              OpcoesGrupoId = c.Opcao.OpcoesGrupoId,
                                              ProdutoId = c.Opcao.ProdutoId,
                                              Fracoes = c.Opcao.Fracoes,
                                              Produto = new Produto
                                              {
                                                 
                                                  ProdutoId = c.Opcao.Produto.ProdutoId,
                                                  Nome = c.Opcao.Produto.Nome,
                                                  Descricao = c.Opcao.Produto.Descricao,
                                                  Status = c.Opcao.Produto.Status,
                                                  IsIndustrializado = c.Opcao.Produto.IsIndustrializado,
                                                  DataCriacao = c.Opcao.Produto.DataCriacao,
                                                  Unidade = c.Opcao.Produto.Unidade,
                                                  Peso = c.Opcao.Produto.Peso,
                                                  ComercioUId = c.Opcao.Produto.ComercioUId,
                                                  Serving = c.Opcao.Produto.Serving,
                                                  RestriocaoAlimentar = c.Opcao.Produto.RestriocaoAlimentar,
                                                  Ean = c.Opcao.Produto.Ean,
                                                  CatalogoStatus = c.Opcao.Produto.CatalogoStatus != null ? c.Opcao.Produto.CatalogoStatus.Select(st => new CatalogoStatus
                                                  {
                                                      Id = st.Id,
                                                      Status = st.Status,
                                                      ProdutoId = st.ProdutoId,
                                                      CatalogoId = st.CatalogoId,
                                                      DataCriacao = st.DataCriacao,
                                                      Catalogo = st.Catalogo,
                                                      Produto = new Produto
                                                      {
                                                      
                                                          ProdutoId = st.Produto.ProdutoId,
                                                          Nome = st.Produto.Nome,
                                                          Descricao = st.Produto.Descricao,
                                                          Status = st.Produto.Status,
                                                          IsIndustrializado = st.Produto.IsIndustrializado,
                                                          DataCriacao = st.Produto.DataCriacao,
                                                          Unidade = st.Produto.Unidade,
                                                          Peso = st.Produto.Peso,
                                                          ComercioUId = st.Produto.ComercioUId,
                                                          Serving = st.Produto.Serving,
                                                          RestriocaoAlimentar = st.Produto.RestriocaoAlimentar,
                                                          Ean = st.Produto.Ean,
                                                          CatalogoStatus = st.Produto.CatalogoStatus != null ? st.Produto.CatalogoStatus.Select(s => new CatalogoStatus
                                                          {
                                                              Id = s.Id,
                                                              Status = s.Status,
                                                              ProdutoId = s.ProdutoId,
                                                              CatalogoId = s.CatalogoId,
                                                              DataCriacao = s.DataCriacao,
                                                              Catalogo = s.Catalogo,
                                                              Produto = new Produto
                                                              {
                                                                 
                                                                  ProdutoId = s.Produto.ProdutoId,
                                                                  Nome = s.Produto.Nome,
                                                                  Descricao = s.Produto.Descricao,
                                                                  Status = s.Produto.Status,
                                                                  IsIndustrializado = s.Produto.IsIndustrializado,
                                                                  DataCriacao = s.Produto.DataCriacao,
                                                                  Unidade = s.Produto.Unidade,
                                                                  Peso = s.Produto.Peso,
                                                                  ComercioUId = s.Produto.ComercioUId,
                                                                  Serving = s.Produto.Serving,
                                                                  RestriocaoAlimentar = s.Produto.RestriocaoAlimentar,
                                                                  Ean = s.Produto.Ean,
                                                                  CatalogoStatus = s.Produto.CatalogoStatus != null ? s.Produto.CatalogoStatus.Select(stt => new CatalogoStatus
                                                                  {
                                                                      Id = stt.Id,
                                                                      Status = stt.Status,
                                                                      ProdutoId = stt.ProdutoId,
                                                                      CatalogoId = stt.CatalogoId,
                                                                      DataCriacao = stt.DataCriacao,
                                                                      Catalogo = stt.Catalogo,
                                                                  }).ToList() : new List<CatalogoStatus>(),
                                                              }

                                                          }).ToList() : new List<CatalogoStatus>(),

                                                      }


                                                  }).ToList() : new List<CatalogoStatus>(),
                                              },


                                          },

                                      }).ToList() : new List<Contexto>(),

                                      }).ToList() : new List<Opcoes>(),
                              }
                          }).ToList() : new List<ProdutoOpcoesGrupo>()


                      },
                      CategoriaId = it.CategoriaId,
                      Categoria = new Categoria
                      {
                       
                          CategoriaId = it.Categoria.CategoriaId,
                          Nome = it.Categoria.Nome,
                          Descricao = it.Categoria.Descricao,
                          DataCriacao = it.Categoria.DataCriacao,
                          ComercioUId = it.Categoria.ComercioUId
                      }
                  })
                
                  .ToListAsync();

              return items;*/

        }

        public async Task<Produto> GetItemsByIdsAsync(Guid itemId, Guid OwnerId)
        {
            /*   var itemUpdate = await _contextCatalogs.Produtos
                          .Where(c => c.Items.Categoria.ComercioUId == OwnerId && c.Items.ItemId == itemId)
                   .FirstOrDefaultAsync();*/

            return null;

        }

        public async Task<Opcoes> GetOpcaoByIdAsync(Guid optionId, Guid produtoId)
        {
            /*  var entityOpcoes = await _contextCatalogs.Opcoes
                  .Where(o => o.OpcaoId == optionId && o.Produto.ComercioUId == produtoId)
                  .Select(op => new Opcoes
                  {

                      OpcaoId = op.OpcaoId,
                      Status = op.Status,
                      OpcoesGrupoId = op.OpcoesGrupoId,
                      ProdutoId = op.ProdutoId,
                      Fracoes = op.Fracoes,

                  }).FirstOrDefaultAsync();*/

            return null;
        }




        public async Task<Produto> UpdateAsync(Produto item)
        {
            /*  _contextCatalogs.Produtos.Update(item);
               await _contextCatalogs.SaveChangesAsync();
               return item;*/
            return null;
        }

        public async Task<Opcoes> UpdateOptionAsync(Opcoes option)
        {
            /*  _contextCatalogs.Opcoes.Update(option);
              await _contextCatalogs.SaveChangesAsync();  
              return option;*/
            return null;
        }





        public async Task<Opcoes> GetOpcaoByIdAsync(Guid optionId)
        {
            /*    var option = await _contextCatalogs.Opcoes
                    .Where(op => op.OpcaoId == optionId)
                    .Include(op=>op.contextos)
                    .ThenInclude(st=> st.CatalogoStatus)

                    .FirstOrDefaultAsync();*/

            return null;
        }
    }
}
