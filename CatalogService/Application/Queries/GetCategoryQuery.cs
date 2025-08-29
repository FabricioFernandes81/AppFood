using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCategoryQuery
    {
        public string MerchantId { get; set; }
        public GetCategoryQuery(string merchantId)
        {
            MerchantId = merchantId?.Trim();
        }
        public GetCategoryQuery()
        {
            // Construtor vazio para compatibilidade com o padrão CQRS
        }
    }
}
