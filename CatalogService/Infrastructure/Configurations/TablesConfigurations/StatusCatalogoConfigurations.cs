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
    public class StatusCatalogoConfigurations : IEntityTypeConfiguration<StatusCatalogo>
    {
        public void Configure(EntityTypeBuilder<StatusCatalogo> builder)
        {
           builder.HasKey(b=>b.StatusCatalogoId);

            builder.HasIndex(a => a.StatusCatalogoId)
                .IsUnique();

            builder.HasOne(i => i.Item)
                .WithMany(i => i.StatusCatalogo)
                .HasForeignKey(i => i.ItemsId);


        }
    }
}
