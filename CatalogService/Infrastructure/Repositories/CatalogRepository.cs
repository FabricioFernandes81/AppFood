
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
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ContextCatalogs _contextCatalogs;

        public CatalogRepository(ContextCatalogs contextCatalogs)
        {
            _contextCatalogs = contextCatalogs;
        }

        public async Task<List<Catalogo>> GetAll(Guid catalogId, Guid merchantId)
        {
            var entity = await _contextCatalogs.Catalogos
                .Include(c=>c.Contexto)
                .ToListAsync();

                return entity;
        }

        public async Task<List<Catalogo>> GetCatalogsByMerchantIdAsync(Guid merchantId)
        {
           var entity = await _contextCatalogs.Catalogos
                .Where(c=>c.ComercioId == merchantId)
                .ToListAsync();
            
            return entity;
        }
    }
}
