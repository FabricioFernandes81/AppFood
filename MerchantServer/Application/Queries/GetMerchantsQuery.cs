using Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetMerchantsQuery : IQuery<List<MerchantSummary>>
    {
        public string UserId { get; set; }

    }
}
