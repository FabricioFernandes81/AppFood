using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCategoryByIdQuery
    {
        public string CategoryId { get; set; }
        public string MerchantId { get; set; }
        public GetCategoryByIdQuery(string categoryId, string merchantId)
        {
            CategoryId = categoryId?.Trim();
            MerchantId = merchantId?.Trim();
        }
       
        public GetCategoryByIdQuery()
        {
        }
    }
}
