using Domain.Juncoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations.TablesConfigurations
{
    public class ProdutoOpcoesGrupoConfigurations : IEntityTypeConfiguration<ProdutoOpcoesGrupo>
    {
        public void Configure(EntityTypeBuilder<ProdutoOpcoesGrupo> builder)
        {
            builder.HasKey(b=>new {b.GrupoId , b.ProdutoId});

            builder.HasOne(builder => builder.GrupoOpcoes)
                .WithMany(b => b.ProdutoOpcoesGrupo)
                .HasForeignKey(b => b.GrupoId);

            builder.HasOne(builder=> builder.Produto)
                .WithMany(b=>b.ProdutoOpcoesGrupo)
                .HasForeignKey(p=>p.ProdutoId);


        }
    }
}
