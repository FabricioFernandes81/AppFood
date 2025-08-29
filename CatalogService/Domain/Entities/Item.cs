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
        public int Id { get; set; }
        public ResourceItemTipo Tipo { get; set; }
      //  public ResourceStatus Status { get; set; }
        public int Index { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public Guid ItemId { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
