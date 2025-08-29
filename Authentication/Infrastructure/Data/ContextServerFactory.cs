using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContextServerFactory : IDesignTimeDbContextFactory<ContextServer>
    {
        public ContextServer CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextServer>();
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AutenticationServer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Corrigido: ContextServer espera DbContextOptions<ContextServer>
            return new ContextServer(optionsBuilder.Options);
        }
    }
}
