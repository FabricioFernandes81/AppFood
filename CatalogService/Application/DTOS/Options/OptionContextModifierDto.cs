using Application.DTOS.items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.Options
{
    public class OptionContextModifierDto
    {
        public string Status { get; set; }
        public string parentOptionId { get; set; }

        public List<StatusByCatalog> StatusByCatalog { get; set; }
    }
}
