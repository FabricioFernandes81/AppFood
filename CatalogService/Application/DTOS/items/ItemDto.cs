using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.items
{
    public class ItemDto
    {
        public int Total { get; set; }

        public List<GetItemDto> Rows { get; set; }
    }
}
