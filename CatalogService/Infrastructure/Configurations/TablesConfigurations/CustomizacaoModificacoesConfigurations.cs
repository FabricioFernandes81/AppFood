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
    public class CustomizacaoModificacoesConfigurations : IEntityTypeConfiguration<CustomizacaoModificacoes>
    {
        public void Configure(EntityTypeBuilder<CustomizacaoModificacoes> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Opcoes)
                .WithMany(c=>c.CustomizacaoModificacoes)
                .HasForeignKey(o => o.customizationOptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(builder => builder.parentCustomizationOptions)
                .WithMany(p=>p.ParentCustomizacaoModificacoes)
                .HasForeignKey(builder => builder.parentCustomizationOptionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(builder => builder.Item)
                .WithMany(c=>c.CustomizacaoModificacoes)
                .HasForeignKey(b => b.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
