using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.product
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Industrialized { get; set; }
        public string Status { get; set; }
        public List<string> OfferTypes { get; set; }

        public List<AvailableAt> availableAt { get; set; }

        public string Unit { get; set; }
        public double Quantity { get; set; }

    }


    public class AvailableAt
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<string> Promotions { get; set; } = new List<string>();
        public List<string> Restrictions { get; set; } = new List<string>();
    }
}
