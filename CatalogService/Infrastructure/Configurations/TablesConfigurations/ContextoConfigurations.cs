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
    public class ContextoConfigurations : IEntityTypeConfiguration<Contexto>
    {
        public void Configure(EntityTypeBuilder<Contexto> builder)
        {
           builder.HasKey(builder => builder.Id);

            builder.HasOne(c => c.Opcao)
                .WithMany(o => o.Context)
                .HasForeignKey(c => c.OpcaoId);

            builder.HasOne(c => c.Opcao)
                .WithMany(o => o.Context)
                .HasForeignKey(c => c.parentOptionId);

        }
    }
}
