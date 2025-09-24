
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IRepositories
{
    public interface ICatalogRepository
    {
        Task<List<Catalogo>> GetAll(Guid catalogId, Guid merchantId);
        Task<List<Catalogo>> GetCatalogsByMerchantIdAsync(Guid merchantId);
     //   Task<Catalogo> GetCatalogByIdAsync(Guid catalogId, Guid merchantId);
    }
}
