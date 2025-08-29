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
    public class ComercioConfigurations : IEntityTypeConfiguration<Domain.Entities.Comercio>
    {
        public void Configure(EntityTypeBuilder<Comercio> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.HasIndex(p => p.UUID)
                .IsUnique();

            builder.HasOne(c => c.Cozinha)
                .WithOne(c => c.Comercio)
                .HasForeignKey<Comercio>(c => c.CozinhaCode);
        }
    }
}
