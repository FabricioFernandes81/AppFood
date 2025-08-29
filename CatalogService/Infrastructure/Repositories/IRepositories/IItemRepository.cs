
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
    }
}
