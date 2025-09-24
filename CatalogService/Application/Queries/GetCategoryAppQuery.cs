﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetCategoryAppQuery
    {
        public string MerchantId { get; set; }
        public string CatalogId { get; set; }
        public bool IncludeItems { get; set; } = false;

    }
}
