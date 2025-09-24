using Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contexto
    {
        public Guid Id { get; set; }
       
        public Guid CatalogoId { get; set; }

        public Catalogo Catalogo { get; set; }
        public ResourceTipoCatalogo ContextoType { get; set; }
    }
}
