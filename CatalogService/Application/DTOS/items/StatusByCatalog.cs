using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.items
{
    public class StatusByCatalog
    {
        public string Status { get; set; }
        public string CatalogId { get; set; }
        public string CatalogType { get; set; }
        public bool Available { get; set; }
    }
}
