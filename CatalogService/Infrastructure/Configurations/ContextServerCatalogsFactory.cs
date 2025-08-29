using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ContextServerCatalogsFactory : IDesignTimeDbContextFactory<ContextCatalogs>
    {
        public ContextCatalogs CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ContextCatalogs>();
            builder.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CatalogsServer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new ContextCatalogs(builder.Options);
        }
    }
}
