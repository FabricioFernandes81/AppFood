
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Produto>> GetPageAsync(int page, int pageSize, Guid merchantId);

    }
}
