
using Domain.Entities;
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

        public Task<List<Categoria>> GetCategoriesAsync(Guid merchantId)
        {
            var entityCategories = _context.Categorias
                .AsNoTracking()
                .Where(c => c.ComercioUId == merchantId)
                .Include(c => c.Items)
                .ToListAsync();
            return entityCategories;
        }
    }
}
