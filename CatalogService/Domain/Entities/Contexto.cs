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
        public int Id { get; set; }
        public Guid ContextoId { get; set; }
        public int OpcaoId { get; set; }
        public int parentOptionId { get; set; }

        public Opcoes Opcao { get; set; }

        public ResourceStatus Status { get; set; }
        //Preço 
    }
}
