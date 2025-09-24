using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.TablesConfigurations
{
    public class CategoriaConfigurations : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(builder => builder.CategoriaId);
            builder.HasIndex(builder => builder.CategoriaId).IsUnique();

            builder.HasOne(c => c.Catalogo)
                .WithMany(c => c.Categorias)
                .HasForeignKey(c => c.CatalogoId);
                
            
        }
    }
}
