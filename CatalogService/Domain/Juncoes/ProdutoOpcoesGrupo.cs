using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Juncoes
{
    public class ProdutoOpcoesGrupo
    {
        public Guid ProdutoId { get; set; }
        public Guid GrupoId { get; set; }

        public Produto Produto { get; set; }
        public GrupoOpcoes GrupoOpcoes { get; set; }
    }
}
