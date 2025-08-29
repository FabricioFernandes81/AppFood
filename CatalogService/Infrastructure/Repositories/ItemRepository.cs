
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
    public class ItemRepository : IItemRepository
    {
        private readonly ContextCatalogs _contextCatalogs;
        public ItemRepository(ContextCatalogs contextCatalogs)
        {
            _contextCatalogs = contextCatalogs;
        }

        public async Task<List<Item>> GetItemsByCategoryAsync(Guid category, Guid OwnerId)
        {
            var items = await _contextCatalogs.Itens
                .Select(it=> new Item
                {
                    Id = it.Id,
                    ItemId = it.ItemId,
                    Tipo = it.Tipo,
                    Index = it.Index,
                    DataCriacao = it.DataCriacao,
                    ProdutoId = it.ProdutoId,
                    Produto = new Produto
                    {
                        Id = it.Produto.Id,
                        ProdutoId = it.Produto.ProdutoId,
                        Nome = it.Produto.Nome,
                        Descricao = it.Produto.Descricao,
                        Status = it.Produto.Status,
                        IsIndustrializado = it.Produto.IsIndustrializado,
                        DataCriacao = it.Produto.DataCriacao,
                        Unidade = it.Produto.Unidade,
                        Peso = it.Produto.Peso,
                        ComercioUId = it.Produto.ComercioUId,
                        ProdutoOpcoesGrupo = it.Produto.ProdutoOpcoesGrupo != null ? it.Produto.ProdutoOpcoesGrupo
                        .Select(og=> new ProdutoOpcoesGrupo
                        {
                            GrupoId = og.GrupoId,
                            ProdutoId = og.ProdutoId,
                            GrupoOpcoes = new GrupoOpcoes 
                            {
                                Id=og.GrupoOpcoes.Id,
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
                                    Id = op.Id,
                                    OpcaoId = op.OpcaoId,
                                    Status = op.Status,
                                    OpcoesGrupoId = op.OpcoesGrupoId,
                                    ProdutoId = op.ProdutoId,
                                    Fracoes = op.Fracoes,
                                    Produto = op.Produto,
                                    
                                    Context = op.Context != null ? op.Context.Select(c=> new Contexto
                                    {
                                        Id = c.Id,
                                        ContextoId = c.ContextoId,
                                        Status = c.Status,
                                        OpcaoId = c.OpcaoId,
                                        parentOptionId = c.parentOptionId,
                                         Opcao = new Opcoes
                                         {
                                             Id = c.Opcao.Id,
                                             OpcaoId = c.Opcao.OpcaoId,
                                             Status = c.Opcao.Status,
                                             OpcoesGrupoId = c.Opcao.OpcoesGrupoId,

                                             //  OpcoesGrupoId = c.Opcao.OpcoesGrupoId,
                                             ProdutoId = c.Opcao.ProdutoId,
                                             Fracoes = c.Opcao.Fracoes,
                                             Produto = c.Opcao.Produto,
                                         }
                                    }).ToList() : new List<Contexto>()
                                 }).ToList() : new List<Opcoes>(),
                            }
                        }).ToList() : new List<ProdutoOpcoesGrupo>()
                        

                    },
                    CategoriaId = it.CategoriaId,
                    Categoria = new Categoria
                    {
                        Id = it.Categoria.Id,
                        CategoriaId = it.Categoria.CategoriaId,
                        Nome = it.Categoria.Nome,
                        Descricao = it.Categoria.Descricao,
                        DataCriacao = it.Categoria.DataCriacao,
                        ComercioUId = it.Categoria.ComercioUId
                    }
                })
                .Where(c => c.Categoria.CategoriaId == category && c.Categoria.ComercioUId == OwnerId)
                .ToListAsync();

            return items;
        }
    }
}
