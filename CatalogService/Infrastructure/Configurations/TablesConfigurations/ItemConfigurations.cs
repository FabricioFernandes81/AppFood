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
    public class ItemConfigurations : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.ItemId);

            builder.HasIndex(i => i.ItemId)
                .IsUnique();

            builder.HasOne(i => i.Categoria)
                .WithMany(c=>c.Items)
                .HasForeignKey(i=>i.CategoriaId);

            /* builder.HasOne(i => i.Produto)
                 .WithOne(builder => builder.Items)
                 .HasForeignKey<Produto>(p=>p.Id);
            */
        }
    
    
    }
}
