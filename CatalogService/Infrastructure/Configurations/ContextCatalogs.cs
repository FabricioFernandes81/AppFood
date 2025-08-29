
using Domain.Entities;
using Domain.Juncoes;
using Infrastructure.Configurations.TablesConfigurations;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ContextCatalogs : DbContext
    {
       
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<GrupoOpcoes> GrupoOpcoes { get; set; }
        public DbSet<Opcoes> Opcoes { get; set; }
        public DbSet<ProdutoOpcoesGrupo> ProdutoOpcoesGrupos { get; set; }
        public DbSet<Contexto> Contextos { get; set; }
        public ContextCatalogs(DbContextOptions<ContextCatalogs> options) : base(options) 
        {
          //  modelBuilder.ApplyConfiguration(new ComercioConfigurations());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InicializerFaker.FakerInicializa(modelBuilder);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaConfigurations());
            modelBuilder.ApplyConfiguration(new ProdutoConfigurations());
            modelBuilder.ApplyConfiguration(new ItemConfigurations());
            modelBuilder.ApplyConfiguration(new GrupoOpcoesConfigurations());
            modelBuilder.ApplyConfiguration(new OpcoesConfigurations());
            modelBuilder.ApplyConfiguration(new ProdutoOpcoesGrupoConfigurations());
            modelBuilder.ApplyConfiguration(new ContextoConfigurations());
            //   modelBuilder.ApplyConfiguration(new OpcoesGrupoOpcoesConfigurations());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

    }
}
