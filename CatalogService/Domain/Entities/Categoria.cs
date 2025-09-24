using Domain.Enuns;
using Domain.Juncoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public ResourceStatus Status { get; set; }
        public ResourceItemTipo Tipo { get; set; }
        public int Index { get; set; }
   

        public List<Item>? Items { get; set; }
        public DateTime DataCriacao { get; set; }

        public Guid CatalogoId { get; set; }
        public virtual Catalogo Catalogo { get; set; }
       
      //  public List<Pizza> Pizzas { get; set; }
       

    }
}
