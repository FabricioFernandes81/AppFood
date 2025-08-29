
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

    //    Task<Categoria> GetCategoryByIdAsync(Guid categoryId, Guid merchantId);

   //     Task<Categoria> CreateCategoryAsync(Categoria category);
   //     Task<CatalogoCategoria> CreateCatalogCategoryAsync(CatalogoCategoria catalogoCategoria);
    }
}
