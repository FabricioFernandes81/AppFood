using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCatalogApiQuery
    {
        private string _merchantId , _catalogId;

        public GetCatalogApiQuery(string merchantId , string catalogId)
        {
            _merchantId = merchantId;
            _catalogId = catalogId;
        }

        public string MerchantId
        { get { return _merchantId; } 
          set { _merchantId = value; } 
        }
        public string CatalogId
        {
            get { return _catalogId; }
            set { _catalogId = value; }
        }
        

    }
}
