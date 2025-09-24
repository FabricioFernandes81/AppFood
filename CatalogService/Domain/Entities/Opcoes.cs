using Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Opcoes
    {
        public Guid OpcaoId { get; set; }
        public ResourceStatus Status { get; set; }
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public Guid OpcoesGrupoId { get; set; }
        public GrupoOpcoes GrupoOpcoes { get; set; }
        
        public List<int>? Fracoes { get; set; }
        public List<CustomizacaoModificacoes> CustomizacaoModificacoes { get; set; }

        public List<CustomizacaoModificacoes> ParentCustomizacaoModificacoes { get; set; }
    }
}
