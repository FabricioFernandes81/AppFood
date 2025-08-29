using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.product
{
    public class GetProductResponseDto
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Offset { get; set; }
        public List<ProductDto> Data { get; set; }
    }
}
