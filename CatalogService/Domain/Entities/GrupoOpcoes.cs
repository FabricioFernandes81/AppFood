using Domain.Enuns;
using Domain.Juncoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GrupoOpcoes
    {
        public int Id { get; set; }
        public Guid OpcaoGrupoId { get; set; }
        public string? Nome { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public ResourceStatus Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ProdutoOpcoesGrupo> ProdutoOpcoesGrupo {  get; set; }
    //    public int ProdutoId { get; set; }
    //    public Produto? Produto { get; set; }
        public int Index { get; set; }
        public ResourceGrupoType ResourceGroupoType { get; set; }
        public List<Opcoes>? Opcoes { get; set; }

    }
}
