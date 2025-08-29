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
    public class CozinhaConfigurations : IEntityTypeConfiguration<Domain.Entities.Cozinha>
    {
        public void Configure(EntityTypeBuilder<Cozinha> builder)
        {
            builder.HasKey(c=>c.Code);
            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}
