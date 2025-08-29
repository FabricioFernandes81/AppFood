using Application.DTOS.catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCatalogQuery :IQuery<List<GetCatalogDto>>
    {
        public string MerchantId { get; set; }

    }
}
