using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.catalog
{
    public class GetCatalogDto
    {
        public string CatalogId { get; set; }
        public string OwnerId { get; set; }
        public string CatalogName { get; set; }
        public string? CatalogDescription { get; set; }
        public string Status { get; set; }
        public string CatalogGroup { get; set; }
        public string CatalogType { get; set; }
        public bool Available { get; set; }
    }
}
