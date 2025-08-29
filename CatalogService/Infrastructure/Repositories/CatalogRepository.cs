
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
            _contextCatalogs = contextCatalogs ?? throw new (nameof(contextCatalogs));
        }

       
    }
}
