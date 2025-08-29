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
    public class OpcoesConfigurations : IEntityTypeConfiguration<Opcoes>
    {
        public void Configure(EntityTypeBuilder<Opcoes> builder)
        {
          builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.OpcaoId).IsUnique();

            builder
              .Property(e => e.Fracoes)
              .HasConversion(
                  v => string.Join(',', v),
                  v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

            builder.HasOne(p => p.GrupoOpcoes)
                .WithMany(b => b.Opcoes!)
                .HasForeignKey(p => p.OpcoesGrupoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
