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
        public int ProdutoId { get; set; }
        public int GrupoId { get; set; }

        public Produto Produto { get; set; }
        public GrupoOpcoes GrupoOpcoes { get; set; }
    }
}
