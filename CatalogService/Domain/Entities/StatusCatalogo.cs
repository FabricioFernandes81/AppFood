using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StatusCatalogo
    {
        public Guid StatusCatalogoId { get; set; }

        public Guid? ItemsId { get; set; }
        public Item Item { get; set; }
    }
}
