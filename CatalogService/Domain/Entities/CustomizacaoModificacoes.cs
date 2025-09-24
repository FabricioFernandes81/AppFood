using Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomizacaoModificacoes
    {
        public Guid Id { get; set; }

        public Guid customizationOptionId { get; set; }

        public Opcoes Opcoes { get; set; }

        public Guid parentCustomizationOptionId { get; set; }

        public Opcoes parentCustomizationOptions { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public ResourceStatus Status { get; set; }

    }
}
