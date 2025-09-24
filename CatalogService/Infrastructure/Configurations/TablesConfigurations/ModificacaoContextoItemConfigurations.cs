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
    public class ModificacaoContextoItemConfigurations : IEntityTypeConfiguration<ModificacaoContextoItem>
    {
        public void Configure(EntityTypeBuilder<ModificacaoContextoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Item)
                .WithMany(m=>m.ContextoItems)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
 

            builder.HasOne(c => c.Catalogo)
                .WithMany(c=>c.ContextoItems)
                .HasForeignKey(c => c.CatalogoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
