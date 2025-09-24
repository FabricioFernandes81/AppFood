
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<List<Categoria>> GetCategoriesAsync(Guid merchantId);
        Task<List<Categoria>> GetCategoriesAsync(Guid merchantId, Guid catalogId, bool includeItems);

        Task<Categoria> GetCategoryByIdAsync(Guid categoryId, Guid merchantId);

        Task<Categoria> UpdateCategoryAsync(Categoria categoria);
   //     Task<Categoria> CreateCategoryAsync(Categoria category);
   //     Task<CatalogoCategoria> CreateCatalogCategoryAsync(CatalogoCategoria catalogoCategoria);
    }
}
