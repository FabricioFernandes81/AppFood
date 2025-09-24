using Domain.Enuns;
using Domain.Juncoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Catalogo
    {
        public Guid CatalogoId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public bool Disponivel { get; set; }

        public ResourceStatus Status { get; set; }
        public ResourceTipoCatalogo Tipo { get; set; }

        public List<Categoria> Categorias { get; set; }

        //foreign keys do Grupo de Catalogo
        public Guid CatalogoGrupo { get; set; }

        public List<Contexto> Contexto {get;set;}
        public Guid ComercioId { get; set; }

        public List<ModificacaoContextoItem> ContextoItems { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
