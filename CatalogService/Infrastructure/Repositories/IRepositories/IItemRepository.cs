
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IRepositories
{
    public interface IItemRepository
    {

        Task<List<Item>> GetItemsByCategoryAsync(Guid category,Guid OwnerId);
        Task<Produto> GetItemsByIdsAsync(Guid itemId, Guid OwnerId);

        Task<Produto> UpdateAsync(Produto produto);
       // Task<CatalogoStatus> GetSatusCatalogoById(Guid catalogoId, Guid produtoId);

       // Task<CatalogoStatus> UpdateStatusCatalogoAsync(CatalogoStatus catalogoStatus);

        Task<Opcoes> GetOpcaoByIdAsync(Guid optionId, Guid produtoId);
        Task<Opcoes> UpdateOptionAsync(Opcoes option);
       // Task<CatalogoStatus> AddStatusCatalogoAsync(CatalogoStatus status);

        //
       // Task<ItemModificacaoContexto> GetContexto(Guid optionId, Guid parentOptionId);
       // Task<List<ItemModificacaoContexto>> UpdateContexto(List<ItemModificacaoContexto> contexto);
       // Task AtualizarCatalogoStatusDoContexto(int contextoId, List<CatalogoStatus> novosStatus);

        Task<Opcoes> GetOpcaoByIdAsync(Guid optionId);
    }
}
