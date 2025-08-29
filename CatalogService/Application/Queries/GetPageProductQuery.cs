using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetPageProductQuery
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string MerchantId { get; set; }
        public GetPageProductQuery(int page = 1, int pageSize = 10, string merchantId = null)
        {
            Page = page;
            PageSize = pageSize;
            MerchantId = merchantId;
        }
        public IEnumerable<object> GetParameters { get; set; }
    }
}
