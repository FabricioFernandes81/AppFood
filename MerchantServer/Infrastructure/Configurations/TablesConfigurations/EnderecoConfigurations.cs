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
    public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {

            //VARCHAR(8)
            builder.HasKey(e => e.ComercioId);
            builder.HasOne(builder => builder.Comercio)
                   .WithOne(comercio => comercio.Endereco)
                   .HasForeignKey<Endereco>(e => e.ComercioId);

            builder.Property(e => e.CEP)
                     .HasMaxLength(8);
        }
    }
}
