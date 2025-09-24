using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.items.postStatus
{
    public class PUTItemsStatusDto
    {
        public List<CategoriesDtos> Categories {  get; set; }
        public List<ItemStatusDto> items { get; set; }
    }

    public class CategoriesDtos
    {
        public string? CategoryId { get; set; }
        public string Status { get; set; }

    }

    public class ItemStatusDto 
    {

        public string? CatalogItemId { get; set; }

        public string? Status { get; set; }
        public List<PutStatusByCatlogs>? statusByCatalog { get; set; }

        
    }

}
