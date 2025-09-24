
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
    public class ProductRepository : IProductRepository
    {
        private readonly ContextCatalogs _contextCatalogs;

        public ProductRepository(ContextCatalogs contextCatalogs)
        {
            _contextCatalogs = contextCatalogs;
        }

        public async Task<IEnumerable<Produto>> GetPageAsync(int page, int pageSize, Guid merchantId)
        {
            /*  var skip = (page - 1) * pageSize;
              var products = await _contextCatalogs.Produtos
                  .Include(p => p.Items)
                  .ThenInclude(ca=>ca.Categoria)
                  .Include(p => p.ProdutoOpcoesGrupo)
                  .ThenInclude(g => g.GrupoOpcoes)
                      .ThenInclude(g => g.Opcoes)
                      .ThenInclude(p=>p.Produto)
                   .Where(p => p.ComercioUId == merchantId && p.Items.Tipo == Domain.Enuns.ResourceItemTipo.DEFAULT)

                  .Skip(skip)
                  .Take(pageSize)
                  .AsNoTracking()
                  .ToListAsync();

              return products;*/
            return null;

        }
    }
}
