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
    public class ProdutoConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(builder => builder.ProdutoId)
                .IsUnique();

            builder.HasOne(i => i.Items)
                .WithOne(i => i.Produto)
                .HasForeignKey<Item>(builder => builder.ProdutoId);
                
        }
    }
}
