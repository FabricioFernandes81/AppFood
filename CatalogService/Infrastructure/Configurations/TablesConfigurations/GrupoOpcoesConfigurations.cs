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
    public class GrupoOpcoesConfigurations : IEntityTypeConfiguration<GrupoOpcoes>
    {
        public void Configure(EntityTypeBuilder<GrupoOpcoes> builder)
        {
            builder.HasKey(g => g.Id);
            builder.HasIndex(g => g.OpcaoGrupoId)
                .IsUnique();
            /*builder.HasOne(g => g.Produto)
                .WithMany(p => p.OpcoesGrupos)
                .HasForeignKey(g => g.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);*/

        }
    }
}
