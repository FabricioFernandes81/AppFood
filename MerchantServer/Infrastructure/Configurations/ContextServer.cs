using Domain.Entities;
using Infrastructure.Configurations.TablesConfigurations;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ContextServer :DbContext
    {

        public DbSet<Comercio> Comercio { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cozinha> Cozinhas { get; set; }
        public ContextServer(DbContextOptions<ContextServer> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ComercioConfigurations());
            modelBuilder.ApplyConfiguration(new EnderecoConfigurations());
            modelBuilder.ApplyConfiguration(new CozinhaConfigurations());
            InicializerFaker.FakerInicializa(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
