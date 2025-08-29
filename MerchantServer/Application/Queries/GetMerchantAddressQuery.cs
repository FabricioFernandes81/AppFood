using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetMerchantAddressQuery
    {
        public string MerchantId { get; set; }
        public string UserId { get; set; }
        public GetMerchantAddressQuery(string merchantId, string userId)
        {
            MerchantId = merchantId;
            UserId = userId;
        }   
    }
}
