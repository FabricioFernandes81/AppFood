using Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        
        public Guid ItemId { get; set; }
        public ResourceItemTipo Tipo { get; set; }
        public int Index { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
       

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public List<ModificacaoContextoItem> ContextoItems { get; set; }

        public List<CustomizacaoModificacoes> CustomizacaoModificacoes { get; set; }
        public List<StatusCatalogo> StatusCatalogo { get; set; }
    }
}
