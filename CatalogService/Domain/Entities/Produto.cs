using Domain.Enuns;
using Domain.Juncoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public ResourceStatus Status { get; set; }
        public bool IsIndustrializado { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? Unidade { get; set; }
        public int Peso { get; set; } = 0;
        public Guid ComercioUId { get; set; }
        public string? Ean { get; set; }


        public ResourceProdutoServer Serving { get; set; } = ResourceProdutoServer.NOT_APPLICABLE;
        public List<ResourceRestricaoAlimentar>? RestriocaoAlimentar { get; set; }
        //    public ResourceTipo Tipo { get; set; }
        public Item? Items { get; set; }
        public List<ProdutoOpcoesGrupo>? ProdutoOpcoesGrupo { get; set; }

    }
}
