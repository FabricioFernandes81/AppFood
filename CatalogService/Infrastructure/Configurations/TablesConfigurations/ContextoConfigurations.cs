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
            builder.HasIndex(c=>c.Id)
                .IsUnique();


            builder.HasOne(c => c.Catalogo)
                .WithMany(c=>c.Contexto)
                .HasForeignKey(c => c.CatalogoId);
         /*   builder.HasOne(c => c.Opcao)
                .WithMany(c => c.Context)
                .HasForeignKey(c => c.OpcaoId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(c => c.ParentOption)
                .WithMany(c=>c.contextos)
                .HasForeignKey(c => c.parentOptionId)
                .OnDelete(DeleteBehavior.Restrict);
         */
        }
    }
}
